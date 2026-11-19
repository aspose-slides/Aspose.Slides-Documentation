---
title: Python を使用してプレゼンテーションに 3D 効果を作成する
linktitle: 3D プレゼンテーション
type: docs
weight: 232
url: /ja/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D プレゼンテーション
- 3D 回転
- 3D 奥行き
- 3D 押し出し
- 3D グラデーション
- 3D テキスト
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で PowerPoint のシェイプとテキストに 3D 効果を適用し、レンダリングします。カメラ、照明、マテリアル、押し出し、塗りつぶし、そして 3D テキストを設定します。"
---
## **概要**

Aspose.Slides for Python via .NET は、シェイプとテキストに対して PowerPoint スタイルの 3D 書式設定を作成、編集、保持、レンダリングできます。この記事では、回転、押し出し、ベベル、照明、マテリアル、グラデーションまたは画像の塗りつぶし、および 3D テキストなどの 3D 効果について説明します。

{{% alert color="info" title="Note" %}}
この記事は、PowerPoint のシェイプとテキストに対する 3D 書式設定効果についてです。単体の 3D モデル ファイルの挿入や編集については扱いません。スライドを画像、PDF、または HTML にエクスポートする際、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには、[Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) プロパティを使用します。このプロパティは、シェイプの 3D シーンを制御する [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) を公開します。

テキストの場合は、[TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) プロパティを使用します。これにより、シェイプ本体ではなくテキスト フレームに 3D 書式設定が適用されます。

最も重要なプロパティは次のとおりです：

| プロパティ | 制御内容 | 使用タイミング |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | 視点、プリセット カメラ タイプ、回転、ズーム、パースペクティブ。 | オブジェクトを 3D 空間で回転させる、または PowerPoint の 3D 回転プリセットに合わせる。 |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | ライトのプリセット、方向、ライト回転。 | ハイライトとシャドウが 3D 表面にどのように表示されるかを変更します。 |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | フラット、マット、プラスチック、メタルなどの表面素材。 | 同じジオメトリをより平らに、柔らかく、光沢のある、または金属的に見せる。 |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | シェイプが前面からどれだけ後方に伸びるか。 | 平らなシェイプを視覚的に厚い 3D オブジェクトに変える。 |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | 押し出された側面の色。 | 奥行きを見えるようにし、または側面の色を前面の塗りと合わせる。 |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | PowerPoint の 3D 書式設定で使用される追加の奥行き。 | シェイプやテキストの奥行きを微調整する、特にベベルやマテリアル設定と組み合わせる場合。 |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) と [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | 前面および背面のエッジを上げたり丸めたりする。 | 鋭い平面の代わりに、柔らかいまたは成形されたエッジを追加する。 |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) と [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | 3D オブジェクトの周囲の輪郭線。 | レンダリングされた出力でオブジェクトの境界を強調する。 |

## **3D シェイプの作成**

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れる可能性があるため。
- ライト設定：照明により面と側面が見やすくなるため。
- マテリアル設定：表面が光の描画に影響するため。
- 押し出しまたは奥行き設定：平面のシェイプに厚みが必要なため。

以下の例は長方形を作成し、前面にテキストを追加して 3D 書式設定を適用します。カメラ回転値は度単位、押し出し高さは 100 ポイントです。例はスライドを PNG 画像に 2 倍のデフォルトサイズでレンダリングし、プレゼンテーションを PPTX として保存します。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

レンダリングされたスライド画像は、長方形が厚い 3D ブロックとして表示されます：

![前面に白い 3D テキストがある青い 3D 四角形のレンダリング画像](img_01_01.png)

## **カメラでシェイプを回転する**

PowerPoint では、3D 回転は「3‑D 回転」ペインから設定します。X、Y、Z の回転値はカメラ API で設定する回転に対応します。

![X、Y、Z の回転値がハイライトされた PowerPoint の 3‑D 回転ペイン](img_02_01.png)

Aspose.Slides では、[ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) を通じてカメラにアクセスします。この例は長方形を作成し、正投影の正面ビューを選択し、X、Y、Z の回転をそれぞれ 20、30、40 度に設定します。ファイルを保存せずにメモリ上でシェイプを構成します：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

ビューアがオブジェクトを見る角度を変更したいときにカメラを使用します。スライド上の 2D シェイプのジオメトリは変更されません。PowerPoint と Aspose.Slides がレンダリング時に使用する 3D ビューポイントが変更されます。

### **テンプレート シェイプからカメラ向きをコピーする**

テンプレート シェイプの向きを合わせるには、[camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) プリセットをコピーし、[get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/) で回転を取得します。例は `template.pptx` を開き、1 枚目のスライドの最初のシェイプから 2 番目のシェイプへカメラ向きをコピーします。両シェイプは既に 3D ライティングが設定されており、2 番目のシェイプには明示的なカメラ回転がありません。

角度は度単位です。インデックス `0`、`1`、`2` はそれぞれ緯度、経度、回転を保持します。この順序で [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) に渡します。ソースに明示的な回転がない場合、`get_rotation` は `None` を返すので、宛先の角度は設定しません。ソースがすべての角度をゼロに明示的に設定している場合は、そのゼロをコピーします。

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

`camera-copy.pptx` を PowerPoint で再度開くと、両シェイプは同じカメラプリセットと回転を持ちます。右側の矢印は左側の長方形からコピーした向きを使用しています。両シェイプは同じライティングと押し出し奥行きを使用します。

![上から右側から見た、カメラ向きが一致した青い 3D 四角形と右矢印](camera-orientation.png)

## **押し出しと奥行きの追加**

押し出しは前面の裏側にシェイプを伸ばすことで厚みを表現します。PowerPoint では奥行きコントロールがこの可視厚みを設定し、色コントロールが側面の色を設定します。

![PowerPoint の奥行きコントロールが押し出し色と押し出し高さプロパティにマッピングされている様子](img_02_02.png)

厚みには [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) を、側面の色には [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) を設定します。この例は長方形に 100 ポイントの押し出しと紫色の側面を付け、カメラを回転させて厚みを見せます。ファイルを保存せずにメモリ上でシェイプを構成します：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

[ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) プロパティは 3D シェイプの奥行きを設定します。[extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) プロパティは押し出し効果の高さを制御し、以下の例で示されています。

## **グラデーションまたは画像塗りつぶしを 3D 効果と併用する**

3D 書式設定はシェイプの塗りつぶしとは独立しています。前面に単色、グラデーション、パターン、または画像塗りつぶしを適用しつつ、同じカメラ、ライト、マテリアル、押し出し設定を使用できます。

この例は前面に青からオレンジへのグラデーションを適用し、150 ポイントの押し出し側面を暗オレンジ色にします。グラデーション ストップは 0 と 100 が開始と終了を示します。カメラ回転値は度単位です。スライドは PNG 画像に 2 倍のデフォルトサイズでレンダリングされます：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

レンダリングされた出力は前面のグラデーションを保持し、押し出しは別途レンダリングされます：

![青からオレンジへのグラデーション塗りとオレンジの押し出しを持つ 3D 四角形のレンダリング画像](img_02_03.png)

画像塗りつぶしを使用する場合は、画像をプレゼンテーションに追加し、シェイプの塗りつぶしに割り当てます。この例は作業ディレクトリに `image.jpg` という名前の既存ファイルがあることを前提とします。画像を長方形全体に伸ばし、150 ポイントの押し出しを適用し、カメラ回転を度単位で設定します。ファイルを保存またはレンダリングせずにメモリ上でシェイプを構成します：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

画像は前面にレンダリングされ、押し出しは 3D 側面として描画されます：

![前面に写真塗りつぶし、オレンジの押し出しを持つ 3D 四角形のレンダリング画像](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響し、テキストの 3D 書式設定はテキスト フレームに影響します。これは、文字自体に押し出し、マテリアル、照明、カメラ設定が必要な WordArt のような効果に便利です。

以下の例はオレンジと白の格子パターンでテキストを作成し、上向きアーチを適用し、[TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) で 3D 設定を構成します。押し出し高さと奥行きはポイント単位、ライト回転は度単位です。シェイプの塗りつぶしと輪郭は非表示にしてテキストだけが見えるようにします。例は PNG 画像に 2 倍のデフォルトスライドサイズでレンダリングし、プレゼンテーションを PPTX として保存します：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

テキストは曲線状に押し出された 3D 文字としてレンダリングされます：

![アーチ形の WordArt 変形、オレンジのパターン塗りつぶし、暗い押し出しを持つ 3D テキストのレンダリング画像](img_02_05.png)

## **3D シェイプ上でテキストを平面に保つ**

シェイプの 3D 外観を保ちつつテキストの可読性を維持するには、[TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/) を [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/) から設定します。値が `True` の場合、テキストは 3D シーンから除外されます。`False` の場合、テキストはシーンに参加し、3D の向きに従います。

この設定はシェイプの 3D 書式設定（カメラ、ライティング、マテリアル、押し出し）を削除しません。これらは引き続き [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) で構成されています。また、通常の回転とは異なります。[Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) はスライド平面上でシェイプを回転させ、[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) はテキストのバウンディング ボックス内でのカスタム回転を制御します。テキストを 3D シーンから除外しても、これらの角度はリセットされません。

以下の自己完結型例は、テキスト付きの青い長方形を作成し、元の隣にクローンします。両シェイプは同じ 3D 書式設定を持ち、テキスト設定だけが異なります：左側は `False`、右側は `True`。カメラ角度は度単位、押し出し高さは 40 ポイントです。例はプレゼンテーションを PPTX として保存し、比較スライドを PNG に 2 倍のデフォルトサイズでレンダリングします。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

左側はテキストが 3D 向きに従い、右側は平面のままで読みやすくなります。両長方形は同じ可視押し出しと 3D 向きを保持しています。

![左右に並んだ 3D 四角形：左が keep_text_flat=False、右が True](keep_text_flat.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は、PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスタライズされ、2D 結果として出力に描画されます。これは、スライドを [PNG](/slides/ja/python-net/convert-powerpoint-to-png/) にレンダリングしたり、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/) にエクスポートしたり、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/) にエクスポートしたり、[video conversion](/slides/ja/python-net/convert-powerpoint-to-video/) 用のフレームを生成したりする場合にも適用されます。

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。
- 最終的な外観はカメラ、ライト リグ、マテリアル、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承またはテーマベースの書式設定値を確認する必要がある場合は、[effective shape properties](/slides/ja/python-net/shape-effective-properties/) を読み取ります。
- 一部の出力形式は、編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、視覚的な結果がレンダリングされ、編集可能な 3D 設定として保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプとテキストの PowerPoint 3D 効果を作成およびレンダリングします。エクスポートされた画像、PDF、HTML ページはインタラクティブな 3D シーンにはならず、ビューアが回転させることはできません。PPTX では、形式がサポートされている限り、3D 書式設定は PowerPoint で編集可能なままです。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は、回転、押し出し、ベベル、照明、マテリアルなどの通常の PowerPoint シェイプまたはテキストに適用される書式設定です。本記事は 3D 効果について取り上げています。

**可視的な 3D シェイプに必要な設定は何ですか？**

最低限、カメラ回転と押し出しまたは奥行きを設定します。実務では、ライト リグとマテリアルも設定して、レンダリングされた面に明確なハイライトとシャドウが出るようにします。

**シェイプとテキストの両方に 3D 効果を適用できますか？**

はい。シェイプ本体には [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) を、テキストには [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) を使用します。

**画像、PDF、HTML、またはビデオフレームにエクスポートしたときに 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。最終的なカメラ、ライト リグ、ベベル、関連する 3D 値を取得するには、[Shape Effective Properties](/slides/ja/python-net/shape-effective-properties/) に記載された有効な書式設定 API を使用します。