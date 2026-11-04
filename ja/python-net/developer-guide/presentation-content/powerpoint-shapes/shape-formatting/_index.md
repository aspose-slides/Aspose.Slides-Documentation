---
title: Python で PowerPoint の図形をフォーマットする
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
- 白黒図形レンダリング
- グレースケール図形レンダリング
- 図形の回転
- 3D ベベル効果
- 3D 回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で PowerPoint の図形をフォーマットする方法を学びます — PPT、PPTX、ODP ファイルに対して、塗りつぶし、線、効果のスタイルを正確かつ完全にコントロールできます。"
---
## **導入**

PowerPoint の図形を輪郭、塗りつぶし、効果を調整して書式設定します。Aspose.Slides for Python via .NET を使用すると、透明度、回転、3D 書式設定などの設定をプログラムで制御できます。

![Shape formatting options in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via .NET は、PowerPoint で利用できる同じオプションを使用して図形をフォーマットできるクラスとプロパティを提供します。

## **線の書式設定**

[Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) を使用して図形の輪郭を制御します。この例では、塗りつぶしのない長方形を青い破線の輪郭で作成します。[LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) で太線・細線のコンパウンド線を選択し、[LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) で幅を 7 ポイントに、[LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) で破線パターンを選択します。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The formatted lines in the presentation](formatted-lines.png)

### **カスタム線破線パターンの設定**

事前定義された線スタイルで必要な破線長さや間隔が得られない場合は、[LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) を使用します。たとえば、ブランドの輪郭や技術図で使用します。パターンを設定すると自動的に [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) が [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) に設定されます。

リスト項目は破線と間隔の長さを交互に並べ、破線から開始します。各値は線幅の倍数です。幅が 3 ポイントの場合、`[4, 2]` は 12 ポイントの破線と 6 ポイントの間隔になります。有限かつ非負の値のペアで完全な破線‑間隔セグメントを定義します。この例では、すべての破線と間隔が見えるよう正の値を使用しています。

この例は、同じ長さでフラットなキャップを持つ 5 本の青い線を作成します。最初の 3 本は幅 3 ポイントでパターンを比較し、4 本目は最初のパターンを幅 2 倍（破線と間隔も 2 倍）で繰り返し、5 本目はカスタムパターンから実線に切り替えます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # 最後の線を実線スタイルに戻す。
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

事前定義された破線スタイルに戻す場合は、[LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) を [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) に割り当てます。選択したスタイルが線の外観を制御します。

PowerPoint での結果（上から順に）: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; および **Solid, 3 pt**。

![Three custom dash patterns, a wider line using the first pattern, and a solid line in PowerPoint](custom-dash-patterns.png)

### **線キャップの設定**

[LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) を使用して開いた線の端を設定します。[LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) 列挙体は次の 3 つの明示的なキャップスタイルを提供します。

- `FLAT`: ストロークは端点で止まります。
- `ROUND`: 半円形のキャップが端点を線幅の半分だけ超えて伸びます。
- `SQUARE`: 正方形のキャップが端点を線幅の半分だけ超えて伸びます。

列挙体には `NOT_DEFINED` も含まれ、これはキャップスタイルが明示的に割り当てられていないことを意味します。

キャップは矢印ヘッドとは異なり、矢印ヘッドは線端にシンボルを追加し、ジョインは線セグメント間の角を制御します。この例では、[LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) と [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) を無効にして、キャップ形状だけを比較しています。

以下の例は、幅 20 ポイントの水平線を 3 本作成します。上から順にフラット、ラウンド、スクエアのキャップを使用します。端点の水平座標は同じで、ラウンドとスクエアのキャップは各端点から 10 ポイント伸びます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint の結果（上から順に）: **Flat**, **Round**, **Square**。

![Flat, round, and square caps on identical thick lines in PowerPoint](line-caps.png)

## **図形線へのスケッチ効果の適用**

スケッチ効果は図形線を手描き風に見せます。[Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) で線設定にアクセスし、[LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) でスケッチ設定にアクセスし、[SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) で [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 列挙体から値を選択します。

次の Python コードは、[LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 効果を適用し、明示的に割り当てられた値を取得し、[LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) で効果を削除する方法を示します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

[SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) が返す値は、図形に直接割り当てられた設定を表します。線の書式設定がテーマ、マスタースライド、またはレイアウトスライドから継承される可能性がある場合は、[LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/) を使用し、[ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/) にアクセスし、[ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/) を取得します。実効値は継承が解決された後に実際に適用される書式を反映します。この例は、少なくとも 1 つの図形が存在する既存のプレゼンテーションを前提とし、両方の値を出力します。

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

## **ジョインスタイルの書式設定**

次の 3 つのジョインタイプがあります。

* Round
* Miter
* Bevel

ジョインスタイルは、2 つの輪郭セグメントが角でどのように接続されるかを制御します。角を丸める場合は **Round**、鋭くしたい場合は **Miter**、平坦にしたい場合は **Bevel** を使用します。

![The join style in the presentation](join-style-powerpoint.png)

この例は、幅 15 ポイントの青い輪郭を持つ黒い長方形を 3 つ作成し、[LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) をそれぞれ [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) の miter、bevel、round 値に設定して角の描画方法を比較します。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **鋭角でのミーター結合の制限**

[LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) を使用し、[LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) を [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) に設定すると、鋭角の伸びる長さを制限できます。

制限は、ジョインの内側と外側の角間距離を線幅で割った比率です。たとえば `8` の値は線幅の最大 8 倍までミーター長さを許可し、ポイント単位の測定ではありません。角が制限を超えると、PowerPoint はその角でベベル結合を使用します。制限を大きくするとより鋭いポイントになります。この設定はミーター結合にのみ影響し、角が両方の制限内に収まる場合は見た目に変化はありません。

この例は、幅 20 ポイントの輪郭を持つ同一の塗りつぶしなし三角形を 2 つ作成します。左側の三角形は制限 `2`、右側は `8` を使用します。各三角形は幅 80 ポイント・高さ 160 ポイントで、上部の角のミーター長さ‑線幅比は約 `4.12` です。その結果、PowerPoint は左側の頂点をベベルし、右側はそのまま保持します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint の結果: 左側 **Miter limit 2**、右側 **miter limit 8**。

![A beveled apex with miter limit 2 and a pointed apex with miter limit 8 in PowerPoint](miter-limits.png)

## **グラデーション塗りつぶし**

グラデーション塗りつぶしは、図形全体に色をブレンドします。この例では、[FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/) を使用して、赤から紫への 45 度の線形グラデーションで楕円を塗りつぶします。[GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) メソッドで 0 と 1（グラデーションの開始点と終了点）にカラーストップを配置します。既存のストップをクリアすることで、これら 2 色だけが使用されます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The ellipse with gradient fill](gradient-fill.png)

エクスポートされた画像でグラデーションの見え方が PowerPoint と異なる場合は、[Choose a Gradient Rendering Style](/slides/ja/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) を参照してください。プレゼンテーションに保存されたグラデーション塗りつぶしを変更せずに、レンダリングスタイルを選択できます。

### **線形グラデーション角度の設定**

[GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) を使用して、[GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) 塗りつぶしの向きを制御します。角度は度数で測定され、時計回りに増加します: `0` は左から右、`90` は上から下、`180` は右から左、`270` は下から上です。小数角度もサポートされています。`[0, 360)` 以外の有限角度は 1 回転に正規化され、例として `-45` は `315`、`360` は `0` になります。

この例は、位置 `0`、`0.5`、`1` に同一の赤・緑・青ストップを持つ 6 つの長方形を作成します。スケーリングを無効にして、角度を長方形の形状に依存せず比較できるようにしています。左から右への角度は、上段が `0`、`45`、`90`、下段が `135`、`180`、`270` です。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint の結果:

![Linear gradients at 0, 45, and 90 degrees in the top row, and 135, 180, and 270 degrees in the bottom row](linear-gradient-angles.png)

### **図形に合わせて線形グラデーションをスケールする**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) は [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) を受け取ります。`FALSE` に設定すると、図形のサイズが変わっても幾何学的なグラデーション角度が保持され、`TRUE` に設定すると幅と高さに合わせてグラデーションがスケールします。スケーリングが有効な非正方形図形では、見た目の角度が割り当てた角度と異なる場合があります。

以下の例は、`45` 度の角度と同じカラーストップを使用します。左列は `FALSE`、右列は `TRUE` です。各列には幅の広い長方形と高さの高い長方形があり、2 番目の長方形の幅と高さを変更して、塗りつぶしがリサイズにどのように対応するかを示します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint の結果（左はスケーリング無効、右は有効）:

![Wide and tall rectangles with a 45-degree gradient, comparing linear_gradient_scaled FALSE on the left with TRUE on the right](linear-gradient-scaling.png)

スケーリングを無効にすると、対角線の色帯は両方の長方形で同じ向きを保ちます。スケーリングを有効にすると、帯は図形の比例に合わせて伸びます。これにより、テンプレートのグラデーションを別サイズの図形に適用する際に再現しやすくなります。正方形の場合、スケーリングを有効にしてもこの `45` 度グラデーションの外観は変わりません。

角度とスケーリング設定は線形グラデーションにのみ適用され、[GradientShape.RADIAL] や [GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) の塗りつぶしは制御しません。

### **角度とグラデーション方向の組み合わせ**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) は [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/) 列挙体からグラデーションスタイルを選択し、数値角度の代わりにはなりません。線形グラデーションの場合、コーナースタイルは色が配布される領域を変えることができ、[linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) を変更せずに角度やスケーリングを比較できます。方向を変更しても角度を変更しても結果は変わりません。

以下の例は、同じ設定を逆順で適用します。2 つの長方形は同一の外観になり、方向を角度の前後で設定しても結果は変わりません。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **パターン塗りつぶし**

パターン塗りつぶしは、ドット、ストライプ、チェックなどの二色デザインを適用します。この例では、[PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) でトレリスパターンを選択し、[PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) でライトグレーの背景色を、[PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) で黄色のパターン色を設定します。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The rectangle with pattern fill](pattern-fill.png)

## **画像塗りつぶし**

画像塗りつぶしは、図形内に画像を配置します。この例ではローカル画像が必要で、[Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) を使用してプレゼンテーションの画像コレクションに読み込みます。[PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) をタイルモードに設定すると、画像が長方形内で繰り返されます。使用した元画像は以下のとおりです。

![The lotus picture](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The shape with picture fill](picture-fill.png)

### **画像をテクスチャとしてタイル配置する**

タイル画像をテクスチャとして設定し、タイル動作をカスタマイズしたい場合は、[PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) クラスの次のプロパティを使用できます。

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): `TILE` または `STRETCH` のいずれかを設定します。
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): タイルの配置を指定します。
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): タイルを水平、垂直、または両方で反転させるかを制御します。
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): 図形の原点からタイルの水平オフセット（ポイント）を設定します。
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): 図形の原点からタイルの垂直オフセット（ポイント）を設定します。
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): タイルの水平スケールをパーセンテージで定義します。
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): タイルの垂直スケールをパーセンテージで定義します。

この例はローカル画像を使用し、元サイズの 50% に縮小して繰り返すように [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) を構成します。`-32` ポイントのオフセットでタイルを水平・垂直にシフトし、右下揃えと両方向のフリップで繰り返しテクスチャの配置を決定します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The tile options](tile-options.png)

## **単色塗りつぶし**

単色塗りつぶしは、図形に単一の均一な色を付けます。この例は、[FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) を単色モードに設定し、[FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) で黄色を割り当て、長方形をプレゼンテーションに保存します。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The shape with solid color fill](solid-color-fill.png)

## **スライドの背景を図形の塗りつぶしとして使用する**

スライドの背景に合わせて図形を塗りつぶす必要がある場合（例: プレゼンテーションテンプレート）には、[AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) を使用します。最初に [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) を [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) に設定して明示的な塗りつぶしを削除します。この組み合わせにより、図形はスタイル塗りつぶしではなくスライドの背景を使用します。フラグだけを有効にしても既存の明示的な塗りつぶしは削除されません。

これは [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) とは異なります。背景塗りつぶしは図形の背後にあるオブジェクトをスライド背景の対応領域で覆いますが、No Fill はそれらのオブジェクトを表示したままにします。グラデーションは各図形内で再開始せず、スライド全体に合わせて配置されます。

以下の例は、スライドが継承するマスターバックグラウンドを作成し、3 つの長方形の背後にマゼンタのバンドを配置します。左の長方形は背景を使用し、中央は No Fill、右は背景塗りつぶしから明示的なオレンジ塗りつぶしに切り替えます。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # マスターからグラデーションを継承します。
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # このオブジェクトを最初に追加すると、長方形の背面に表示されます。
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # 明示的な塗りつぶしを適用する前に背景塗りつぶしを無効にします。
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

結果（左から右）: **background fill**, **no fill**, **explicit fill**。マゼンタバンドは左と右の長方形で隠れますが、中央の長方形を通しては見えます。

![Background fill, no fill, and explicit orange fill over a magenta band](background-fill.png)

同様の動作はスライド自体に直接定義された背景やレイアウトから継承された背景にも適用されます。図形はスライドの解決された背景を使用します。この例ではスライドとレイアウトの背景を未設定のままにし、マスターが提供するようにしています。

## **透明度の設定**

単色塗りつぶしの場合、色のアルファ成分が不透明度を制御します: 0 が完全に透明、255 が完全に不透明です。この例では黄色の長方形にアルファ値 128 を使用し、約 50% の透明度にして下の長方形が見えるようにしています。色は [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) で割り当てます。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The transparent shape](shape-transparency.png)

## **図形の回転**

[Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) を使用して、スライド平面上で図形を回転させます。角度は度数で測定され、この例では長方形を時計回りに 5 度回転させてプレゼンテーションを保存します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The shape rotation](shape-rotation.png)

## **3D ベベル効果の追加**

[Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) を使用して、図形に奥行きとベベルエッジを付加します。この例は、緑の楕円にオレンジの輪郭を付け、[ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) を 4 ポイントに設定し、[ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) で幅と高さ 6 ポイントの円形トップベベルを適用します。正面向きの正投影カメラと三点照明によりベベルが可視化されます。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D 回転効果の追加**

図形の 3D 表示はカメラ設定で制御されます。この例は、[Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) を使用し、緯度・経度・回転角度をそれぞれ 40、35、20 度に設定します。[Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) で等角投影カメラを選択し、[LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) でバランスの取れた照明を選び、書式設定した長方形を保存します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The 3D rotation effect](3D-rotation-effect.png)

## **図形の白黒レンダリングの制御**

[Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) プロパティは、プレゼンテーションが白黒モードで表示または処理されるときに個々の図形がどのようにレンダリングされるかを指定します。これだけでは白黒表示が有効になるわけではなく、通常のカラー表示時の図形の塗りつぶし、線、その他の書式設定は変更されません。

[BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) 列挙体の値を使用して目的の動作を選択します。例: `AUTOMATIC` は変換方式をアプリケーションに任せ、`GRAY` と `LIGHT_GRAY` はグレースケール、`BLACK_WHITE` は純粋な黒白、`BLACK` と `WHITE` は単一色、`COLOR` は通常のカラーを保持、`HIDDEN` は白黒モードで図形を除外します。`NOT_DEFINED` は図形レベルのモードが割り当てられていないことを意味します。

この例はオレンジの長方形を作成し、[Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) をグレーに設定します。保存された図形は通常のカラー表示ではオレンジの塗りつぶしを保持し、黒白表示をサポートするアプリケーションではグレーで表示されます。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

通常カラー表示では長方形はオレンジの塗りつぶしを保持します。黒白表示のワークフローでは `GRAY` が設定されているためグレーで表示され、フルカラーのスライドを保持しつつ、印刷やプレビューなど黒白設定を尊重するワークフロー向けに別の外観を定義できます。

## **書式設定のリセット**

[Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) を使用して、スライド プレースホルダーの位置、サイズ、書式設定を対応するレイアウト プレースホルダーから復元します。この例は、レイアウトとリンクされたプレースホルダーが存在する既存プレゼンテーションが必要で、保存前にすべてのスライドをリセットします。対応するレイアウト プレースホルダーがない図形はリセットされません。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**形状の書式設定は最終的なプレゼンテーション ファイル サイズに影響しますか？**

色、線スタイル、効果設定は、埋め込み画像やメディアと比較してデータ量はほとんど増えません。画像塗りつぶしは、画像がプレゼンテーションに保存されるためファイルサイズを増加させる可能性があります。

**同一書式設定を共有するスライド上の図形を検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗りつぶし、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルを同一とみなし、論理的にグループ化します。これにより、後のスタイル管理が簡素化されます。

**カスタム図形スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

はい。目的のスタイルを持つサンプル図形をテンプレート スライド デックまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成する際にテンプレートを開き、必要なスタイル済み図形をクローンして、必要な場所で書式設定を再適用します。