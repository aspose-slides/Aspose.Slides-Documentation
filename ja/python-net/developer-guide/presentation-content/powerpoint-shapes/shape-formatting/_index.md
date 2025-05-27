---
title: Python で PowerPoint 図形の書式設定を行う
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/python-net/shape-formatting/
keywords:
- 図形を書式設定
- 線を書式設定
- 結合スタイルを書式設定
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像の塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- 図形の透過性
- 図形を回転
- 3D ベベル効果
- 3D 回転効果
- 書式設定をリセット
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PPT、PPTX、ODP プレゼンテーションの図形の書式設定を行い、塗りつぶし、線、効果スタイルを正確かつ自在に設定する方法を学びましょう。"
---

PowerPointでは、スライドに形を追加できます。形は線から構成されているため、形の構成要素である線を変更または特定の効果を適用することで形をフォーマットできます。さらに、形の領域がどのように塗りつぶされるかを決定する設定を指定することで形をフォーマットできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides for Python via .NET**は、PowerPointの既知のオプションに基づいて形をフォーマットするためのインターフェイスとプロパティを提供します。

## **線をフォーマットする**

Aspose.Slidesを使用して、形の好みの線スタイルを指定できます。これらの手順はその手続きの概要です：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)を追加します。
4. 形の線の色を設定します。
5. 形の線の幅を設定します。
6. 形の線の[line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/)を設定します。
7. 形の線の[dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/)を設定します。
8. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このPythonコードは、長方形の`AutoShape`をフォーマットする操作を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXファイルを表すPresentationクラスのインスタンスを作成
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 長方形のオートシェイプを追加
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # 長方形の形の塗りつぶし色を設定
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.white

    # 長方形の線にいくつかのフォーマットを適用
    shp.line_format.style = slides.LineStyle.THICK_THIN
    shp.line_format.width = 7
    shp.line_format.dash_style = slides.LineDashStyle.DASH

    # 長方形の線の色を設定
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # PPTXファイルをディスクに書き込む
    pres.save("RectShpLn_out-1.pptx", slides.export.SaveFormat.PPTX)
```

## **結合スタイルをフォーマットする**

これが3つの結合タイプのオプションです：

* ラウンド
* ミタ
* ベベル

デフォルトでは、PowerPointは、角度で2つの線を結合する際（または形の角で）、**ラウンド**設定を使用します。しかし、非常に鋭い角度を持つ形を描画したい場合は、**ミタ**を選択することをお勧めします。

![join-style-powerpoint](join-style-powerpoint.png)

このPythonコードは、ミタ、ベベル、ラウンドの結合タイプ設定で3つの長方形（上の画像）が作成された操作を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXファイルを表すPresentationクラスのインスタンスを作成
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 3つの長方形のオートシェイプを追加
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 150, 75)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 150, 75)
    shp3 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 150, 75)

    # 長方形の形の塗りつぶし色を設定
    shp1.fill_format.fill_type = slides.FillType.SOLID
    shp1.fill_format.solid_fill_color.color = draw.Color.black
    shp2.fill_format.fill_type = slides.FillType.SOLID
    shp2.fill_format.solid_fill_color.color = draw.Color.black
    shp3.fill_format.fill_type = slides.FillType.SOLID
    shp3.fill_format.solid_fill_color.color = draw.Color.black

    # 線の幅を設定
    shp1.line_format.width = 15
    shp2.line_format.width = 15
    shp3.line_format.width = 15

    # 長方形の線の色を設定
    shp1.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    shp2.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    shp3.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # 結合スタイルを設定
    shp1.line_format.join_style = slides.LineJoinStyle.MITER
    shp2.line_format.join_style = slides.LineJoinStyle.BEVEL
    shp3.line_format.join_style = slides.LineJoinStyle.ROUND

    # 各長方形にテキストを追加
    shp1.text_frame.text = "これはミタ結合スタイルです"
    shp2.text_frame.text = "これはベベル結合スタイルです"
    shp3.text_frame.text = "これはラウンド結合スタイルです"

    # PPTXファイルをディスクに書き込む
    pres.save("RectShpLnJoin_out-2.pptx", slides.export.SaveFormat.PPTX)
```


## **グラデーション塗りつぶし**
PowerPointでは、グラデーション塗りつぶしは、形に連続的な色のブレンドを適用できるフォーマットオプションです。たとえば、1色が徐々にフェードして別の色に変わる設定で、2色以上を適用できます。

これを使用してAspose.Slidesで形にグラデーション塗りつぶしを適用する方法は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)を追加します。
4. 形の[FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)を`Gradient`に設定します。
5. `GradientFormat`クラスに関連付けられた`GradientStops`コレクションによって提供される`Add`メソッドを使用して、2つの好みの色を定義された位置とともに追加します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このPythonコードは、楕円にグラデーション塗りつぶし効果を使用した操作を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 楕円のオートシェイプを追加
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 75, 150)

    # 楕円にグラデーションフォーマットを適用
    shp.fill_format.fill_type = slides.FillType.GRADIENT
    shp.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # グラデーションの方向を設定
    shp.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # 2つのグラデーションストップを追加
    shp.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shp.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # PPTXファイルをディスクに書き込む
    pres.save("EllipseShpGrad_out-3.pptx", slides.export.SaveFormat.PPTX)
```


## **パターン塗りつぶし**
PowerPointでは、パターン塗りつぶしは、形に点、ストライプ、クロスハッチ、またはチェックで構成された2色デザインを適用できるフォーマットオプションです。さらに、パターンの前景と背景の好みの色を選択できます。

Aspose.Slidesは、形をフォーマットしプレゼンテーションを豊かにするために使用できる45以上の事前定義されたスタイルを提供します。事前定義されたパターンを選択した後でも、パターンに含まれる色を指定できます。

これを使用してAspose.Slidesで形にパターン塗りつぶしを適用する方法は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)を追加します。
4. 形の[FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)を`Pattern`に設定します。
5. 形の好みのパターンスタイルを設定します。
6. [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/)の背景色を設定します。
7. [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/)の前景色を設定します。
8. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このPythonコードは、長方形を美化するためにパターン塗りつぶしを使用した操作を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 長方形のオートシェイプを追加
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # 塗りつぶしタイプをパターンに設定
    shp.fill_format.fill_type = slides.FillType.PATTERN

    # パターンスタイルを設定
    shp.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # パターンの背景色と前景色を設定
    shp.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shp.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # PPTXファイルをディスクに書き込む
    pres.save("RectShpPatt_out-4.pptx", slides.export.SaveFormat.PPTX)
```


## **画像塗りつぶし**
PowerPointでは、画像塗りつぶしは、形の中に画像を配置できるフォーマットオプションです。基本的に、形の背景として画像を使用できるということです。

これを使用してAspose.Slidesで形を画像で塗りつぶす方法は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)を追加します。
4. 形の[FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)を`Picture`に設定します。
5. 画像塗りつぶしモードをタイルに設定します。
6. 形を塗りつぶすために使用する画像を使用して`IPPImage`オブジェクトを作成します。
7. 先ほど作成した`IPPImage`を`PictureFillFormat`オブジェクトの`Picture.Image`プロパティに設定します。
8. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このPythonコードは、形を画像で塗りつぶす方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXファイルを表すPresentationクラスのインスタンスを作成
with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 長方形のオートシェイプを追加
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # 塗りつぶしタイプを画像に設定
    shp.fill_format.fill_type = slides.FillType.PICTURE

    # 画像塗りつぶしモードを設定
    shp.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # 画像を設定
    img = draw.Bitmap(path + "Tulips.jpg")
    imgx = pres.images.add_image(img)
    shp.fill_format.picture_fill_format.picture.image = imgx

    # PPTXファイルをディスクに書き込む
    pres.save("RectShpPic_out-5.pptx", slides.export.SaveFormat.PPTX)
```


## **単色塗りつぶし**
PowerPointでは、単色塗りつぶしは、形を単一色で塗りつぶすことができるフォーマットオプションです。選択された色は通常、プレーンな色です。色は形の背景に適用され、特別な効果や修正はありません。

これを使用してAspose.Slidesで形に単色塗りつぶしを適用する方法は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)を追加します。
4. 形の[FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)を`Solid`に設定します。
5. 形の色を設定します。
6. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このPythonコードは、PowerPointのボックスに単色塗りつぶしを適用する方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # 最初のスライドを取得
    slide = presentation.slides[0]

    # 長方形のオートシェイプを追加
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # 塗りつぶしタイプを単色に設定
    shape.fill_format.fill_type = slides.FillType.SOLID

    # 長方形の色を設定
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # PPTXファイルをディスクに書き込む
    presentation.save("RectShpSolid_out-6.pptx", slides.export.SaveFormat.PPTX)
```

## **透明度の設定**

PowerPointでは、形を単色、グラデーション、画像、またはテクスチャで塗りつぶす際に、塗りつぶしの不透明度を指定して透明度レベルを設定できます。これにより、例えば、不透明度レベルを低く設定すると、形の背後にあるスライドオブジェクトや背景が透けて見えます。

Aspose.Slidesを使用して形の透明度レベルを設定する方法は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)を追加します。
4. `Color.FromArgb`を使用して、アルファコンポーネントを設定します。
5. オブジェクトをPowerPointファイルとして保存します。

このPythonコードはそのプロセスを示します：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # 塗りつぶし形状を追加
    solidShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 75, 175, 75, 150)

    # 塗りつぶし形状の上に透明形状を追加
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("ShapeTransparentOverSolid_out.pptx", slides.export.SaveFormat.PPTX)

```

## **形を回転させる**
Aspose.Slidesを使用して、スライドに追加された形を次の方法で回転させることができます：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)を追加します。
4. 必要な度数だけ形を回転させます。
5. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このPythonコードは、形を90度回転させる方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # 最初のスライドを取得
    sld = pres.slides[0]

    # 長方形のオートシェイプを追加
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # 形を90度回転させる
    shp.rotation = 90

    # PPTXファイルをディスクに書き込む
    pres.save("RectShpRot_out-7.pptx", slides.export.SaveFormat.PPTX)
```


## **3Dベベル効果の追加**
Aspose.Slides for Python via .NETを使用すると、次の方法で形に3Dベベル効果を追加できます：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)を追加します。
4. 形の[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/)プロパティに好みのパラメータを設定します。
5. プレゼンテーションをディスクに書き込みます。

このPythonコードは、形に3Dベベル効果を追加する方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentationクラスのインスタンスを作成
with slides.Presentation() as pres:
    slide = pres.slides[0]

    # スライドに形を追加
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 30, 30, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    format = shape.line_format.fill_format
    format.fill_type = slides.FillType.SOLID
    format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # 形のThreeDFormatプロパティを設定
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # プレゼンテーションをPPTXファイルとして書き込む
    pres.save("Bavel_out-8.pptx", slides.export.SaveFormat.PPTX)
```


## **3D回転効果の追加**
Aspose.Slidesでは、次の方法で形に3D回転効果を適用できます：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに[IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)を追加します。
4. カメラタイプとライトタイプの好みの数値を指定します。
5. プレゼンテーションをディスクに書き込みます。

このPythonコードは、形に3D回転効果を適用する方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentationクラスのインスタンスを作成
with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 200, 200)

    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(40, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.LINE, 30, 300, 200, 200)
    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(0, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    pres.save("Rotation_out-9.pptx", slides.export.SaveFormat.PPTX)
```

## **フォーマットをリセットする**

このPythonコードは、スライドのフォーマットをリセットし、[LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/)にあるすべてのプレースホルダーを持つ形の位置、サイズ、およびフォーマットをデフォルトに戻す方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    for slide in pres.slides:
        # レイアウトにプレースホルダーがある各形状がリセットされる
        slide.reset()
```