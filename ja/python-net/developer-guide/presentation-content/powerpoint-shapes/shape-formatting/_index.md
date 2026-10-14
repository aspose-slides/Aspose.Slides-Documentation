---
title: PythonでPowerPoint図形をフォーマット
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/python-net/shape-formatting/
keywords:
- 図形のフォーマット
- 線のフォーマット
- スケッチ効果
- 図形線のスケッチ
- 結合スタイルのフォーマット
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- 図形の透明度
- 白黒図形レンダリング
- グレースケール図形レンダリング
- 図形の回転
- 3Dベベル効果
- 3D回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で PowerPoint の図形をフォーマットする方法を学びます。PPT、PPTX、ODP ファイル向けに塗りつぶし、線、効果のスタイルを正確かつ完全に制御できます。"
---
## **はじめに**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、輪郭を変更したり効果を適用したりして書式設定できます。また、内部の塗りつぶし方法を制御する設定を指定して図形をフォーマットすることもできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python は、PowerPoint で利用できるのと同じオプションを使用して図形をフォーマットできるクラスとプロパティを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。以下の手順で手順を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
4. 図形の [線スタイル](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) を設定します。
5. 線の幅を設定します。
6. 図形の [破線スタイル](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) を設定します。
7. 図形の線色を設定します。
8. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # Rectangle タイプのオートシェイプを追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # 矩形シェイプの塗りつぶしを削除し、線だけが表示されるようにします。
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

![The formatted lines in the presentation](formatted-lines.png)

## **図形の線にスケッチ効果を適用する**

スケッチ効果は、図形の線を手描きのように見せます。線の設定にアクセスするには [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) を使用し、スケッチ設定にアクセスするには [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) を使用し、[SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) で [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 列挙体から値を選択します。

以下の Python コードは、[LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 効果を適用し、明示的に割り当てられた値を取得し、[LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) で効果を削除する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # 形状の線書式とそのスケッチ書式にアクセスします。
    sketch_format = shape.line_format.sketch_format

    # スケッチ効果を適用します。
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # 形状に直接割り当てられたスケッチ効果を読み取ります。
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # スケッチ効果を削除します。
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

`SketchFormat.sketch_type` が返す値は、図形に直接割り当てられた設定を表します。線の書式設定がテーマ、マスタースライド、レイアウトスライドから継承される場合は、[LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/) を使用して返されたオブジェクトの `sketch_format` プロパティにアクセスし、その `sketch_type` プロパティを読み取ります。Effective 値は、継承が解決された後に実際に適用される書式設定を反映します。

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

次の 3 つの結合タイプオプションがあります：

* ラウンド
* ミータ
* ベベル

デフォルトでは、PowerPoint は角度で 2 本の線を結合する際（たとえば図形の角）に **Round** 設定を使用します。しかし、鋭い角を持つ図形を描く場合は **Miter** オプションを選択した方が適しています。

![The join style in the presentation](join-style-powerpoint.png)

以下の Python コードは、上図のように Miter、Bevel、Round の結合タイプ設定を使用して 3 つの長方形を作成した方法を示しています。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

	# 最初のスライドを取得します。
	slide = presentation.slides[0]

	# Rectangle タイプのオートシェイプを3つ追加します。
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

PowerPoint では、グラデーション塗りつぶしは、図形に連続した色のブレンドを適用できる書式設定オプションです。たとえば、2 つ以上の色を徐々に一方から他方へフェードさせるように適用できます。

Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用する手順は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
4. 図形の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `GRADIENT` に設定します。
5. [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/) クラスが提供する `gradient_stops` コレクションの `add` メソッドを使用して、位置を指定した 2 つの希望する色を追加します。
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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

![The ellipse with gradient fill](gradient-fill.png)

エクスポートされた画像でグラデーションの見た目が PowerPoint と異なる場合は、[グラデーションレンダリングスタイルの選択](/slides/ja/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) を参照してください。プレゼンテーションに保存されたグラデーション塗りつぶしを変更せずに、レンダリングスタイルを選択できます。

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、点、ストライプ、クロスハッチ、チェックなどの 2 色デザインを図形に適用できる書式設定オプションです。パターンの前景色と背景色をカスタムで選択できます。

Aspose.Slides は、プレゼンテーションの視覚的魅力を高めるために図形に適用できる 45 種類以上の事前定義パターンスタイルを提供します。事前定義されたパターンを選択した後でも、使用する正確な色を指定できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
4. 図形の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `PATTERN` に設定します。
5. 事前定義されたオプションからパターンスタイルを選択します。
6. パターンの [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) を設定します。
7. パターンの [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) を設定します。
8. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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

![The rectangle with pattern fill](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、画像を図形の内部に挿入し、実質的に画像を図形の背景として使用できる書式設定オプションです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
4. 図形の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `PICTURE` に設定します。
5. 画像塗りつぶしモードを `TILE`（または別の希望モード）に設定します。
6. 使用したい画像から [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) オブジェクトを作成します。
7. この画像を図形の `picture_fill_format` の `picture.image` プロパティに割り当てます。
8. 変更したプレゼンテーションを PPTX ファイルとして保存します。

![The lotus picture](lotus.png)

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

![The shape with picture fill](picture-fill.png)

### **テクスチャとしてタイル画像を設定**

タイル画像をテクスチャとして設定し、タイル動作をカスタマイズしたい場合は、[PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) クラスの以下のプロパティを使用できます：

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): 画像の塗りつぶしモードを設定します（`TILE` または `STRETCH`）。
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): 図形内でタイルの配置を指定します。
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): タイルを水平、垂直、またはその両方に反転させるかを制御します。
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): 図形の原点からタイルの水平オフセット（ポイント単位）を設定します。
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): 図形の原点からタイルの垂直オフセット（ポイント単位）を設定します。
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): タイルの水平スケールをパーセンテージで定義します。
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): タイルの垂直スケールをパーセンテージで定義します。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    first_slide = presentation.slides[0]

    # 矩形のオートシェイプを追加します。
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # シェイプの塗りつぶしタイプを Picture に設定します。
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # 画像を読み込み、プレゼンテーションのリソースに追加します。
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # 画像をシェイプに割り当てます。
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # 画像塗りつぶしモードとタイル設定プロパティを構成します。
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

![The tile options](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。このシンプルな背景色は、グラデーション、テクスチャ、パターンを使用せずに適用されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
4. 図形の [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `SOLID` に設定します。
5. 好みの塗りつぶし色を図形に割り当てます。
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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

![The shape with solid color fill](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、単色、グラデーション、画像、テクスチャのいずれかで塗りつぶしを適用した図形に対して、透明度レベルを設定して塗りつぶしの不透明度を制御できます。透明度の値が大きいほど、図形が透けて見え、背景や下にあるオブジェクトが部分的に表示されます。

Aspose.Slides では、塗りつぶしに使用する色のアルファ値を調整することで透明度を設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
4. 塗りつぶしタイプを `SOLID` に設定します。
5. `Color.from_argb` を使用して透明度を持つ色を定義します（`alpha` コンポーネントが透明度を制御します）。
6. プレゼンテーションを保存します。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドを取得します。
    slide = presentation.slides[0]
    
    # ソリッド矩形のオートシェイプを追加します。
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # ソリッドシェイプの上に透明な矩形オートシェイプを追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

![The transparent shape](shape-transparency.png)

## **図形の回転**

Aspose.Slides では、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件に合わせてビジュアル要素を回転させる際に便利です。

図形をスライド上で回転させる手順は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
4. 図形の `rotation` プロパティに目的の角度を設定します。
5. プレゼンテーションを保存します。

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

![The shape rotation](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides を使用すると、[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) プロパティを設定して図形に 3D ベベル効果を適用できます。

3D ベベル効果を図形に追加する手順は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
4. 図形の [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) を構成してベベル設定を定義します。
5. プレゼンテーションを保存します。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーション クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # スライドにシェイプを追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # シェイプの ThreeDFormat プロパティを設定します。
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

![The 3D bevel effect](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides を使用すると、[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) プロパティを設定して図形に 3D 回転効果を適用できます。

3D 回転効果を図形に適用する手順は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
4. 図形の [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) と [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) を設定して 3D 回転を定義します。
5. プレゼンテーションを保存します。

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

    # PPTX ファイルとしてプレゼンテーションを保存します。      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

![The 3D rotation effect](3D-rotation-effect.png)

## **図形の白黒レンダリングの制御**

[Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) プロパティは、プレゼンテーションが白黒モードで表示または処理されるときに個々の図形がどのようにレンダリングされるかを指定します。白黒表示自体を有効にするものではなく、通常のカラー表示時の図形の塗りつぶし、線、その他の書式設定を変更するものでもありません。

[BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) 列挙体の値を使用して目的の動作を選択します。たとえば、`AUTOMATIC` はレンダリング アプリケーションに変換を任せ、`GRAY` および `LIGHT_GRAY` はグレーカラーを使用し、`BLACK_WHITE` は黒と白のみ、`BLACK` と `WHITE` は単一色を強制し、`COLOR` は通常のカラーを保持し、`HIDDEN` は白黒モードで図形を省略します。`NOT_DEFINED` は図形レベルのモードが割り当てられていないことを意味します。

以下の Python コードは、色付きの図形を作成し、白黒表示モードで灰色として表示させる方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # カラーモードではオレンジの塗りつぶしを保持し、白黒モードでは図形をグレーカラーで描画します。
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

通常のカラー表示では、長方形はオレンジ色の塗りつぶしが保持されます。白黒表示のワークフローでは、モードが `GRAY` に設定されているため灰色で表示されます。これにより、フルカラーのスライドを保持しつつ、印刷やプレビュー、その他黒白表示設定を尊重するワークフロー向けに別の外観を定義できます。

## **書式設定のリセット**

以下の Python コードは、スライドの書式設定をリセットし、[LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) 上のプレースホルダーを持つすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # レイアウト上のプレースホルダーを持つスライド上の各シェイプをリセットします。
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**図形の書式設定は最終的なプレゼンテーションのファイルサイズに影響しますか？**

ほとんど影響はありません。埋め込み画像やメディアがファイル容量の大部分を占め、色や効果、グラデーションといった図形パラメータはメタデータとして保存され、実質的なサイズ増加はほとんどありません。

**スライド上で同一の書式設定を共有している図形を検出し、グループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗りつぶし、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなし、論理的にそれらの図形をグループ化します。これにより、後でのスタイル管理が簡素化されます。

**カスタム図形スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

はい。目的のスタイルを持つサンプル図形をテンプレートスライド デッキまたは .POTX テンプレートファイルに保存します。新しいプレゼンテーションを作成する際にテンプレートを開き、必要なスタイルの図形をクローンして、必要な場所で書式設定を再適用します。