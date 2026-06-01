---
title: Python を使用したプレゼンテーションの 3D 効果作成
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
description: "Aspose.Slides を使用して Python で PowerPoint のシェイプとテキストに 3D 効果を適用およびレンダリングします。カメラ、照明、素材、押し出し、塗りつぶし、3D テキストを構成します。"
---
## **概要**

Aspose.Slides for Python via .NET は、シェイプやテキストに対して PowerPoint 形式の 3D 書式設定を作成、編集、保持、およびレンダリングできます。この記事では、回転、押し出し、ベベル、照明、素材、グラデーションまたは画像塗りつぶし、そして 3D テキストなどの 3D 効果について説明します。

{{% alert color="primary" %}}
この記事は PowerPoint のシェイプとテキストに対する 3D 書式設定効果についてです。単独の 3D モデル ファイルの挿入や編集については扱いません。スライドを画像、PDF、または HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式概念**

シェイプに 3D 書式を適用するには、[Shape.three_d_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/three_d_format/) プロパティを使用します。このプロパティは [ThreeDFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/) を公開し、シェイプの 3D シーンを制御します。

テキストの場合は、[TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/three_d_format/) プロパティを使用します。これはシェイプ本体ではなくテキスト フレームに 3D 書式を適用します。

最も重要なプロパティは次のとおりです:

| プロパティ | 制御内容 | 使用する場面 |
|---|---|---|
| [camera](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/camera/) | 視点、プリセット カメラ タイプ、回転、ズーム、遠近感。 | 3D 空間でオブジェクトを回転させたり、PowerPoint の 3D 回転プリセットに合わせたりする場合。 |
| [light_rig](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/light_rig/) | ライト プリセット、方向、ライトの回転。 | 3D 表面のハイライトや影の見え方を変更する場合。 |
| [material](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/material/) | フラット、マット、プラスチック、金属などの表面素材。 | 同じ形状を平坦、柔らかい、光沢のある、または金属的に見せたい場合。 |
| [extrusion_height](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/extrusion_height/) | 前面から後方へシェイプがどれだけ伸びるか。 | 平面のシェイプを視覚的に厚みのある 3D オブジェクトに変える場合。 |
| [extrusion_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/extrusion_color/) | 押し出された側面の色。 | 奥行きを見せたり、側面の色を前面の塗りつぶしと合わせたりする場合。 |
| [depth](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/depth/) | PowerPoint の 3D 書式で使用される追加の奥行き。 | シェイプやテキストの奥行きを微調整する場合、特にベベルや素材設定と組み合わせるとき。 |
| [bevel_top](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/bevel_top/) と [bevel_bottom](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/bevel_bottom/) | 前面と背面のエッジを持ち上げたり丸めたりする。 | 鋭利な平面の代わりに、柔らかく成形されたエッジを加えたい場合。 |
| [contour_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/contour_color/) と [contour_width](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/contour_width/) | 3D オブジェクトの輪郭線。 | レンダリング結果でオブジェクトの境界を強調したい場合。 |

## **3D シェイプの作成**

シェイプが説得力のある 3D に見えるようになるには、通常次の 4 種類の設定が必要です:

- カメラ設定 – デフォルトの正面ビューでは押し出しが隠れることがあるため。
- ライト設定 – 照明が面や側面を読みやすくするため。
- 素材設定 – 表面が光の当たり方に影響を与えるため。
- 押し出しまたは奥行き設定 – 平面シェイプに厚みを持たせるため。

以下の例は長方形を作成し、前面にテキストを追加し、3D 書式を適用し、プレゼンテーションを PPTX として保存し、スライドを PNG 画像としてレンダリングします。

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

レンダリングされたスライド画像は、長方形が厚みのある 3D ブロックとして表示されます:

![前面に白い 3D テキストがある青い 3D 長方形のレンダリング結果](img_01_01.png)

## **カメラでシェイプを回転する**

PowerPoint では、3D 回転は「3-D 回転」ペインから設定します。X、Y、Z の回転値はカメラ API を介して設定する回転に対応しています。

![X、Y、Z 回転値が強調表示された PowerPoint の 3-D 回転ペイン](img_02_01.png)

Aspose.Slides では、[ThreeDFormat.camera](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/camera/) を使用してカメラ タイプと回転を設定します:

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

ビューアがオブジェクトを見る方向を変更したいときにカメラを使用します。スライド上の 2D シェイプのジオメトリは変更せず、PowerPoint および Aspose.Slides がレンダリング時に使用する 3D 視点を変更します。

## **押し出しと奥行きを追加する**

押し出しはシェイプの前面の背後に拡張することで厚みを持たせます。PowerPoint では、奥行きコントロールがこの可視厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint の奥行きコントロールが押し出しの色と押し出し高さプロパティに対応している様子](img_02_02.png)

厚さには [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/extrusion_height/) を、側面の色には [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/extrusion_color/) を設定します:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

PowerPoint の奥行き値を直接操作したい場合や、奥行きをベベル、素材、テキスト効果と組み合わせたい場合は [ThreeDFormat.depth](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/depth/) を使用します。多くのシェイプ シナリオでは、可視的な押し出しを直接示す [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/extrusion_height/) の方が分かりやすい設定です。

## **3D 効果と共にグラデーションまたは画像塗りつぶしを使用する**

3D 書式はシェイプの塗りつぶしとは独立しています。前面に単色、グラデーション、パターン、または画像塗りつぶしを適用しながら、同じカメラ、ライト、素材、押し出し設定を使用できます。

以下の例はシェイプにグラデーション塗りつぶしを適用し、側面に暗めの押し出し色を設定します:

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

レンダリング結果は前面のグラデーションを保持し、押し出しは別個に描画されます:

![青からオレンジへのグラデーション塗りとオレンジの押し出しを持つ 3D 長方形のレンダリング結果](img_02_03.png)

画像塗りつぶしを使用する場合は、プレゼンテーションに画像を追加し、シェイプの塗りつぶしに割り当てます:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

画像は前面にレンダリングされ、押し出しは 3D 側面として描画されます:

![前面に写真塗りつぶし、側面にオレンジの押し出しを持つ 3D 長方形のレンダリング結果](img_02_04.png)

## **テキストに 3D 書式を適用する**

シェイプの 3D 書式はシェイプ本体に影響します。テキストの 3D 書式はテキスト フレームに影響します。文字自体に押し出し、素材、照明、カメラ設定が必要な WordArt のような効果に便利です。

次の例はパターン塗りつぶしのテキストを作成し、WordArt 変形を適用し、[TextFrameFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/) の 3D 設定を構成します:

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

テキストは曲線状に押し出された 3D 文字としてレンダリングされます:

![アーチ状の WordArt 変形、オレンジのパターン塗り、暗い押し出しを持つ 3D テキストのレンダリング結果](img_02_05.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint フォーマットに保存するときに 3D 書式を保持します。固定レイアウト形式にレンダリングまたはエクスポートする場合、3D シーンはラスタライズされ、2D の結果として出力に描画されます。これはスライドを [PNG](/slides/ja/python-net/convert-powerpoint-to-png/) にレンダリングする場合、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/) にエクスポートする場合、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/) にエクスポートする場合、または [ビデオ変換](/slides/ja/python-net/convert-powerpoint-to-video/) 用のフレームを生成する場合に適用されます。

留意点:

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。
- 最終的な外観はカメラ、ライト リグ、素材、押し出し、塗りつぶし、スライドの拡大縮小の組み合わせに依存します。
- 継承された設定やテーマベースの書式値を確認する必要がある場合は、[effective shape properties](/slides/ja/python-net/shape-effective-properties/) を参照してください。
- 一部の出力形式は編集可能な PowerPoint 3D 書式を保存できません。そのような形式では、視覚的結果がレンダリングされ、編集可能な 3D 設定としては保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプとテキストの PowerPoint 3D 効果を作成およびレンダリングしますが、エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはできません。PPTX では、フォーマットがサポートしている限り、3D 書式は PowerPoint で編集可能なまま保持されます。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は、回転、押し出し、ベベル、照明、素材などの通常の PowerPoint シェイプまたはテキストに適用される書式です。この記事では 3D 効果について扱います。

**見える 3D シェイプに必要な設定は何ですか？**

最低限、カメラの回転と押し出しまたは奥行きを設定します。実務では、ハイライトと影をはっきりさせるためにライト リグと素材も設定するのが一般的です。

**シェイプとテキストの両方に 3D 効果を適用できますか？**

はい。シェイプ本体には [Shape.three_d_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/three_d_format/) を、テキストには [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/three_d_format/) を使用します。

**画像、PDF、HTML、ビデオフレームにエクスポートするときに 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。最終的なカメラ、ライト リグ、ベベル、その他の 3D 値を取得するには、[Shape Effective Properties](/slides/ja/python-net/shape-effective-properties/) で説明されている有効書式 API を使用してください。