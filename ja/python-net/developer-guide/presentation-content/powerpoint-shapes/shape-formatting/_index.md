---
title: PythonでPowerPointの図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/python-net/shape-formatting/
keywords:
- 図形の書式設定
- 線の書式設定
- スケッチ効果
- 図形線のスケッチ
- 結合スタイルの書式設定
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
description: "Aspose.Slides を使用して Python で PowerPoint の図形をフォーマットする方法を学びます。PPT、PPTX、ODP ファイルに対して、塗りつぶし、線、エフェクトのスタイルを精密かつ完全にコントロールして設定できます。"
---
## **はじめに**

PowerPoint ではスライドに図形を追加できます。図形は線で構成されているため、輪郭線を変更したりエフェクトを適用したりして書式設定できます。また、内部の塗りつぶし方法を指定して図形をフォーマットすることもできます。

![PowerPoint の図形書式設定](format-shape-powerpoint.png)

Aspose.Slides for Python は、PowerPoint で利用できる同じオプションを使用して図形をフォーマットできるクラスとプロパティを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/ja/python-net/aspose.slides/linestyle/) を設定します。
1. 線の幅を設定します。
1. 図形の [dash style](https://reference.aspose.com/slides/ja/python-net/aspose.slides/linedashstyle/) を設定します。
1. 図形の線の色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、矩形の `AutoShape` の線をフォーマットする方法を示しています。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

    # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
    with slides.Presentation() as presentation:

        # 最初のスライドを取得します。
        slide = presentation.slides[0]

        # Rectangle タイプのオートシェイプを追加します。
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

        # 矩形シェイプの塗りつぶし色を設定します。
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

![プレゼンテーションのフォーマットされた線](formatted-lines.png)

## **図形の線にスケッチ効果を適用する**

スケッチ効果は、図形の線を手書き風に見せます。`Shape.line_format` を使用して線設定にアクセスし、`LineFormat.sketch_format` でスケッチ設定にアクセスし、`SketchFormat.sketch_type` で [LineSketchType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/linesketchtype/) 列挙体から値を選択します。

以下の Python コードは、[LineSketchType.CURVED](https://reference.aspose.com/slides/ja/python-net/aspose.slides/linesketchtype/) 効果を適用し、明示的に割り当てられた値を読み取り、[LineSketchType.NONE](https://reference.aspose.com/slides/ja/python-net/aspose.slides/linesketchtype/) で効果を削除する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # 形状の線フォーマットとスケッチフォーマットにアクセスします。
    sketch_format = shape.line_format.sketch_format

    # スケッチ効果を適用します。
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # 形状に直接割り当てられたスケッチ効果を読み取ります。
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # スケッチ効果を削除します。
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

`SketchFormat.sketch_type` が返す値は、図形に直接割り当てられた設定を表します。線の書式設定がテーマ、マスタースライド、またはレイアウトスライドから継承される場合は、[LineFormat.get_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides/lineformat/get_effective/) を使用し、返されたオブジェクトの `sketch_format` プロパティにアクセスして `sketch_type` を読み取ります。Effective 値は継承が解決された後に実際に適用される書式設定を反映します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **結合スタイルの書式設定**

結合タイプのオプションは次の 3 つです。

* Round
* Miter
* Bevel

既定では、PowerPoint は角度のある二つの線（図形のコーナーなど）を結合する際に **Round** 設定を使用します。ただし、鋭角の図形を描く場合は **Miter** オプションを選択した方が好ましいことがあります。

![プレゼンテーションの結合スタイル](join-style-powerpoint.png)

以下の Python コードは、上図のように Miter、Bevel、Round の結合タイプ設定を使用して 3 つの矩形を作成した方法を示しています。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

	# 最初のスライドを取得します。
	slide = presentation.slides[0]

	# Rectangle タイプのオートシェイプを 3 つ追加します。
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# 各矩形シェイプの塗りつぶし色を設定します。
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# 線幅を設定します。
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

PowerPoint のグラデーション塗りつぶしは、図形に連続的な色のブレンドを適用できる書式設定オプションです。たとえば、二つ以上の色を徐々に変化させて塗りつぶすことができます。

Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/filltype/) を `GRADIENT` に設定します。
1. [GradientFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/gradientformat/) クラスが公開する `gradient_stops` コレクションの `add` メソッドを使用し、位置を指定した 2 色以上を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、楕円にグラデーション塗りつぶし効果を適用する方法を示しています。

```python
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # Ellipse タイプのオートシェイプを追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # 楕円にグラデーション書式設定を適用します。
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # グラデーションの方向を設定します。
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # 2 つのグラデーションストップを追加します。
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # PPTX ファイルをディスクに保存します。
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![グラデーション塗りつぶしの楕円](gradient-fill.png)

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、点、ストライプ、クロスハッチ、チェックなどの二色デザインを図形に適用できる書式設定オプションです。パターンの前景色と背景色を自由に設定できます。

Aspose.Slides は、プレゼンテーションの視覚的魅力を高めるために適用できる 45 以上の事前定義パターンスタイルを提供します。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

パターン塗りつぶしを図形に適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/filltype/) を `PATTERN` に設定します。
1. 事前定義オプションからパターンスタイルを選択します。
1. パターンの [back_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/patternformat/back_color/) を設定します。
1. パターンの [fore_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/patternformat/fore_color/) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、矩形にパターン塗りつぶしを適用する方法を示しています。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # Rectangle タイプのオートシェイプを追加します。
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

PowerPoint の画像塗りつぶしは、画像を図形の内部に挿入し、図形の背景として使用できる書式設定オプションです。

Aspose.Slides を使用して図形に画像塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/filltype/) を `PICTURE` に設定します。
1. 画像塗りつぶしモードを `TILE`（または他の希望モード）に設定します。
1. 使用したい画像から [PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) オブジェクトを作成します。
1. この画像を図形の `picture_fill_format` の `picture.image` プロパティに割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の画像は「lotus.png」というファイルの例です。

![ロータス画像](lotus.png)

以下の Python コードは、画像で図形を塗りつぶす方法を示しています。

```python
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # Rectangle タイプのオートシェイプを追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # 塗りつぶしタイプを Picture に設定します。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 画像塗りつぶしモードを設定します。
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # 画像を読み込み、プレゼンテーションのリソースに追加します。
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # 画像を設定します。
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # PPTX ファイルをディスクに保存します。
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![画像塗りつぶしの図形](picture-fill.png)

### **テクスチャとしてタイル画像を使用する**

タイル状の画像をテクスチャとして設定し、タイル配置の動作をカスタマイズしたい場合は、[PictureFillFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/) クラスの次のプロパティを使用できます。

- [picture_fill_mode](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/picture_fill_mode/): `TILE` または `STRETCH` を指定します。
- [tile_alignment](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/tile_alignment/): 図形内でのタイルの配置を指定します。
- [tile_flip](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/tile_flip/): タイルを水平、垂直、または両方に反転するかを制御します。
- [tile_offset_x](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/tile_offset_x/): 図形の原点からタイルの水平オフセット（ポイント）を設定します。
- [tile_offset_y](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/tile_offset_y/): 図形の原点からタイルの垂直オフセット（ポイント）を設定します。
- [tile_scale_x](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/tile_scale_x/): タイルの水平スケールをパーセンテージで定義します。
- [tile_scale_y](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/tile_scale_y/): タイルの垂直スケールをパーセンテージで定義します。

以下のコードサンプルは、タイル画像塗りつぶし付きの矩形を追加し、タイルオプションを構成する方法を示しています。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    first_slide = presentation.slides[0]

    # 矩形のオートシェイプを追加します。
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # 図形の塗りつぶしタイプを Picture に設定します。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 画像を読み込み、プレゼンテーションのリソースに追加します。
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # 画像を図形に割り当てます。
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # 画像塗りつぶしモードとタイルのプロパティを設定します。
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

![タイルオプションのプレビュー](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。グラデーション、テクスチャ、パターンなどは使用されません。

Aspose.Slides を使用して図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/filltype/) を `SOLID` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、PowerPoint スライドの矩形に単色塗りつぶしを適用する方法を示しています。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # Rectangle タイプのオートシェイプを追加します。
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

PowerPoint では、単色、グラデーション、画像、テクスチャ塗りつぶしを図形に適用する際に、透明度レベルを設定して塗りつぶしの不透明度を制御できます。透明度が高いほど図形が透けて見え、背景や下にあるオブジェクトが部分的に表示されます。

Aspose.Slides では、塗りつぶしに使用する色のアルファ値を調整することで透明度を設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. 塗りつぶしタイプを `SOLID` に設定します。
1. `Color.from_argb` を使用して透明度（アルファ）成分を含む色を定義します。
1. プレゼンテーションを保存します。

以下の Python コードは、矩形に透明塗りつぶし色を適用する方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]
    
    # 単色矩形オートシェイプを追加します。
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # ソリッドシェイプの上に透明な矩形オートシェイプを追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![透明な図形](shape-transparency.png)

## **図形の回転**

Aspose.Slides は、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件に合わせて視覚要素を調整する際に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の `rotation` プロパティに目的の角度を設定します。
1. プレゼンテーションを保存します。

以下の Python コードは、図形を 5 度回転させる方法を示しています。

```python
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # Rectangle タイプのオートシェイプを追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # 図形を 5 度回転させます。
    shape.rotation = 5

    # PPTX ファイルをディスクに保存します。
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![図形の回転](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/) プロパティを構成することで 3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスをインスタンス化します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/) を構成し、ベベル設定を定義します。
1. プレゼンテーションを保存します。

以下の Python コードは、図形に 3D ベベル効果を適用する方法を示しています。

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

![3D ベベル効果](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/) プロパティを構成することで 3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. 図形の [camera_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/camera/camera_type/) と [light_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/lightrig/light_type/) を設定して 3D 回転を定義します。
1. プレゼンテーションを保存します。

以下の Python コードは、図形に 3D 回転効果を適用する方法を示しています。

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

![3D 回転効果](3D-rotation-effect.png)

## **書式設定のリセット**

以下の Python コードは、スライドの書式設定をリセットし、[LayoutSlide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/) 上のプレースホルダーを含むすべての図形の位置、サイズ、書式設定を既定に戻す方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # レイアウト上のプレースホルダーがあるスライド上の各シェイプをリセットします。
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**図形の書式設定は最終的なプレゼンテーションのファイルサイズに影響しますか？**

影響はほとんどありません。埋め込み画像やメディアがファイルサイズの大部分を占め、色やエフェクト、グラデーションといった図形パラメータはメタデータとして保存され、実質的なサイズ増加はありません。

**同じ書式設定を持つ図形をスライド上で検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗りつぶし、線、エフェクト設定）を比較します。すべての対応する値が一致すれば、スタイルが同一と見なして論理的にグループ化でき、後のスタイル管理が簡略化されます。

**カスタム図形スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

はい。目的のスタイルを持つサンプル図形をテンプレートスライドデッキまたは .POTX テンプレートファイルに保存します。新規プレゼンテーション作成時にテンプレートを開き、必要なスタイルの図形をクローンして、必要な場所に書式設定を再適用します。