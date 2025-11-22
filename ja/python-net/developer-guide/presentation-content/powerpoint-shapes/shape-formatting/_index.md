---
title: PythonでPowerPointの図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/python-net/shape-formatting/
keywords:
- 図形のフォーマット
- 線のフォーマット
- 結合スタイルのフォーマット
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- 図形の透明度
- 図形の回転
- 3Dベベル効果
- 3D回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で PowerPoint の図形をフォーマットする方法を学びます—PPT、PPTX、ODP ファイルの塗りつぶし、線、効果のスタイルを正確かつ完全にコントロールできます。"
---

## **概要**

PowerPointでは、スライドに図形を追加できます。図形は線で構成されているため、輪郭を変更または効果を適用して線をフォーマットできます。さらに、内部の塗りつぶし方法を制御する設定を指定して図形をフォーマットできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python は、PowerPoint で利用できるのと同じオプションを使用して図形をフォーマットできるクラスとプロパティを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。以下の手順で手順を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) を設定します。
1. 線の太さを設定します。
1. 図形の [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) を設定します。
1. 図形の線の色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、矩形 `AutoShape` の書式設定方法を示します。
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # Rectangle タイプの自動図形を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # 矩形図形の塗りつぶし色を設定します。
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # 矩形の線に書式設定を適用します。
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # 矩形の線の色を設定します。
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # PPTX ファイルをディスクに保存します。
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![プレゼンテーションの書式設定された線](formatted-lines.png)

## **結合スタイルの書式設定**

結合タイプのオプションは次の3つです:

* ラウンド
* ミタ
* ベベル

デフォルトでは、PowerPoint が角度のある2本の線（たとえば図形の角）を結合するとき、**ラウンド** 設定を使用します。ただし、鋭角の図形を描く場合は **ミタ** オプションを好むことがあります。

![プレゼンテーションの結合スタイル](join-style-powerpoint.png)

以下の Python コードは、上の画像に示された3つの矩形がミタ、ベベル、ラウンドの結合タイプ設定を使用して作成された方法を示します。
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

	# 最初のスライドを取得します。
	slide = presentation.slides[0]

	# Rectangle タイプの自動図形を3つ追加します。
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# 各矩形図形の塗りつぶし色を設定します。
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# 線の幅を設定します。
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# 各矩形の線の色を設定します。
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# 結合スタイルを設定します。
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# 各矩形にテキストを追加します。
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# PPTX ファイルをディスクに保存します。
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```


## **グラデーション塗りつぶし**

PowerPoint でのグラデーション塗りつぶしは、図形に連続した色のブレンドを適用できる書式設定オプションです。たとえば、2色以上を徐々にフェードさせる形で適用できます。

以下は、Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用する手順です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `GRADIENT` に設定します。
1. [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/) クラスが公開する `gradient_stops` コレクションの `add` メソッドを使用して、位置を指定した 2 つの好みの色を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、楕円にグラデーション塗りつぶし効果を適用する方法を示します。
```python
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # Ellipse タイプの自動図形を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # 楕円にグラデーション書式を適用します。
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # グラデーションの方向を設定します。
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # グラデーション ストップを2つ追加します。
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # PPTX ファイルをディスクに保存します。
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![グラデーション塗りつぶしの楕円](gradient-fill.png)

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、点、ストライプ、クロスハッチ、チェックなどの二色デザインを図形に適用できる書式設定オプションです。パターンの前景色と背景色をカスタムで選択できます。

Aspose.Slides は、プレゼンテーションの視覚的魅力を高めるために図形に適用できる 45 以上の事前定義パターンスタイルを提供します。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

以下は、Aspose.Slides を使用して図形にパターン塗りつぶしを適用する手順です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `PATTERN` に設定します。
1. 事前定義オプションからパターンスタイルを選択します。
1. パターンの [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) を設定します。
1. パターンの [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、矩形にパターン塗りつぶしを適用する方法を示します。
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # Rectangle タイプの自動図形を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 塗りつぶしタイプを Pattern に設定します。
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # パターンスタイルを設定します。
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # パターンの背景色と前景色を設定します。
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # PPTX ファイルをディスクに保存します。
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![パターン塗りつぶしの矩形](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、画像を図形の内部に挿入し、実質的に画像を図形の背景として使用できる書式設定オプションです。

以下は、Aspose.Slides を使用して図形に画像塗りつぶしを適用する手順です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `PICTURE` に設定します。
1. 画像塗りつぶしモードを `TILE`（または他の好みのモード）に設定します。
1. 使用したい画像から [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) オブジェクトを作成します。
1. この画像を図形の `picture_fill_format` の `picture.image` プロパティに割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の画像は「lotus.png」ファイルの例です。

![ロータスの画像](lotus.png)

以下の Python コードは、画像で図形を塗りつぶす方法を示します。
```python
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # Rectangle タイプの自動図形を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # 塗りつぶしタイプを Picture に設定します。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # ピクチャー 塗りつぶしモードを設定します。
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # 画像を読み込み、プレゼンテーションのリソースに追加します。
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # ピクチャーを設定します。
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # PPTX ファイルをディスクに保存します。
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![画像塗りつぶしの図形](picture-fill.png)

### **テクスチャとしてタイル画像を使用**

画像をタイル状のテクスチャとして設定し、タイルの動作をカスタマイズしたい場合は、[PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) クラスの以下のプロパティを使用します。

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/)：画像の塗りつぶしモードを設定します — `TILE` または `STRETCH`。
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/)：図形内でタイルの配置を指定します。
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/)：タイルを水平方向、垂直方向、または両方に反転させるかを制御します。
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/)：図形の原点からタイルの水平方向オフセット（ポイント単位）を設定します。
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/)：図形の原点からタイルの垂直方向オフセット（ポイント単位）を設定します。
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/)：タイルの水平方向スケールをパーセンテージで定義します。
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/)：タイルの垂直方向スケールをパーセンテージで定義します。

以下のコードサンプルは、タイル画像塗りつぶし付きの矩形形状を追加し、タイルオプションを構成する方法を示します。
```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    first_slide = presentation.slides[0]

    # 矩形の自動図形を追加します。
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # 図形の塗りつぶしタイプを Picture に設定します。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 画像を読み込み、プレゼンテーションのリソースに追加します。
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # 画像を図形に割り当てます。
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # ピクチャー塗りつぶしモードとタイルプロパティを構成します。
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # PPTX ファイルをディスクに保存します。
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![タイルオプションの画像](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。このシンプルな背景色は、グラデーション、テクスチャ、パターンなしで適用されます。

Aspose.Slides を使用して図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `SOLID` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、PowerPoint スライド内の矩形に単色塗りつぶしを適用する方法を示します。
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # Rectangle タイプの自動図形を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 塗りつぶしタイプを Solid に設定します。
    shape.fill_format.fill_type = slides.FillType.SOLID

    # 塗りつぶし色を設定します。
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # PPTX ファイルをディスクに保存します。
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![単色塗りつぶしの図形](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、図形に単色、グラデーション、画像、テクスチャのいずれかの塗りつぶしを適用する際に、透明度レベルを設定して塗りつぶしの不透明度を制御できます。透明度が高いほど図形が透けて見え、背景や下にあるオブジェクトが部分的に表示されます。

Aspose.Slides では、塗りつぶしに使用する色のアルファ値を調整して透明度を設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. 塗りつぶしタイプを `SOLID` に設定します。
1. `Color.from_argb` を使用して透明度付きの色を定義します（`alpha` コンポーネントが透明度を制御します）。
1. プレゼンテーションを保存します。

以下の Python コードは、矩形に透明塗りつぶし色を適用する方法を示します。
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]
    
    # ソリッド矩形の自動図形を追加します。
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # ソリッド形状の上に透明な矩形の自動図形を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![透明な図形](shape-transparency.png)

## **図形の回転**

Aspose.Slides は、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件に合わせて視覚要素の位置を調整する際に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の `rotation` プロパティに目的の角度を設定します。
1. プレゼンテーションを保存します。

以下の Python コードは、図形を 5 度回転させる方法を示します。
```python
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # Rectangle タイプの自動図形を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 図形を 5 度回転させます。
    shape.rotation = 5

    # PPTX ファイルをディスクに保存します。
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![図形の回転](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) プロパティを設定することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) を構成してベベル設定を定義します。
1. プレゼンテーションを保存します。

以下の Python コードは、図形に 3D ベベル効果を適用する方法を示します。
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # スライドに図形を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # 図形の ThreeDFormat プロパティを設定します。
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![3D ベベル効果の画像](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) プロパティを設定することで、3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) と [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) を設定して 3D 回転を定義します。
1. プレゼンテーションを保存します。

以下の Python コードは、図形に 3D 回転効果を適用する方法を示します。
```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # プレゼンテーションを PPTX ファイルとして保存します。      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![3D 回転効果の画像](3D-rotation-effect.png)

## **書式設定のリセット**

以下の Python コードは、スライドの書式設定をリセットし、[LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) 上のプレースホルダー付きすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示します。
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # レイアウトにプレースホルダーがあるスライド上の各シェイプをリセットします。
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**図形の書式設定は最終的なプレゼンテーションのファイルサイズに影響しますか？**

ほとんど影響しません。埋め込まれた画像やメディアがファイルサイズの大部分を占め、色や効果、グラデーションなどの図形パラメータはメタデータとして保存され、実質的にサイズは増加しません。

**同じ書式設定を共有する図形をスライド上で検出し、グループ化するにはどうすればよいですか？**

各図形の主要な書式設定プロパティ（塗りつぶし、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなし、論理的にグループ化します。これにより後続のスタイル管理が簡素化されます。

**カスタム図形スタイルのセットを別ファイルに保存して、他のプレゼンテーションで再利用できますか？**

可能です。目的のスタイルを持つサンプル図形をテンプレートスライドや .POTX テンプレートファイルに保存します。新規プレゼンテーション作成時にテンプレートを開き、必要なスタイルの図形をクローンし、必要な場所で書式設定を再適用します。