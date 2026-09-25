---
title: Python を使用したプレゼンテーションでの 3D 効果作成
linktitle: 3D プレゼンテーション
type: docs
weight: 232
url: /ja/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D プレゼンテーション
- 3D 回転
- 3D 深度
- 3D 押し出し
- 3D グラデーション
- 3D テキスト
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して、Python で PowerPoint のシェイプとテキストに 3D 効果を適用およびレンダリングします。カメラ、照明、マテリアル、押し出し、塗りつぶし、3D テキストを設定します。"
---
## **概要**

Aspose.Slides for Python via .NET は、シェイプやテキストに対して PowerPoint スタイルの 3D 書式設定を作成、編集、保持、レンダリングできます。この記事では、回転、押し出し、ベベル、照明、マテリアル、グラデーションまたは画像の塗りつぶし、そして 3D テキストなどの 3D 効果について説明します。

{{% alert color="info" title="Note" %}}
この記事は、PowerPoint シェイプとテキストに対する 3D 書式設定効果について説明しています。単独の 3D モデルファイルの挿入や編集については扱いません。スライドを画像、PDF、または HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには、[Shape.three_d_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/three_d_format/) プロパティを使用します。このプロパティは、そのシェイプの 3D シーンを制御する [ThreeDFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/) を公開します。

テキストの場合は、[TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/three_d_format/) プロパティを使用します。これによりシェイプ本体ではなくテキスト フレームに 3D 書式設定が適用されます。

最も重要なプロパティは次のとおりです。

| プロパティ | 制御内容 | 使用するタイミング |
|---|---|---|
| [camera](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/camera/) | 視点、プリセットカメラタイプ、回転、ズーム、パースペクティブ。 | オブジェクトを 3D 空間で回転させるか、PowerPoint の 3D 回転プリセットに合わせます。 |
| [light_rig](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/light_rig/) | 光のプリセット、方向、光の回転。 | 3D 表面上のハイライトと影の表示方法を変更します。 |
| [material](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/material/) | 表面素材（フラット、マット、プラスチック、メタルなど）。 | 同じジオメトリをより平坦に、柔らかく、光沢のある、または金属的に見せます。 |
| [extrusion_height](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/extrusion_height/) | シェイプが前面からどれだけ後方に伸びるか。 | 平面のシェイプを目に見えて厚い 3D オブジェクトに変えます。 |
| [extrusion_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/extrusion_color/) | 押し出された側面の色。 | 深さを可視化したり、側面の色を前面の塗りつぶしと調整したりします。 |
| [depth](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/depth/) | PowerPoint の 3D 書式設定で使用される追加の 3D 深さ。 | シェイプやテキストの深さを微調整します。特にベベルやマテリアル設定と組み合わせて使用します。 |
| [bevel_top](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/bevel_top/) と [bevel_bottom](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/bevel_bottom/) | 前面と背面のエッジを高くしたり、丸めたりしたもの。 | 鋭い平面の代わりに、柔らかいまたは成形されたエッジを追加します。 |
| [contour_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/contour_color/) と [contour_width](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/contour_width/) | 3D オブジェクトの輪郭線。 | レンダリング出力でオブジェクトの境界を強調します。 |

## **3D シェイプの作成**

シェイプが説得力のある 3D に見えるまでには、通常、4 種類の設定が必要です：

- カメラ設定（デフォルトの正面ビューでは押し出しが見えないことがあります）。
- 光設定（照明により面や側面が見やすくなります）。
- マテリアル設定（表面が光の当たり方に影響します）。
- 押し出しまたは深さ設定（平面のシェイプに厚みを付けるため）。

次の例は矩形を作成し、正面にテキストを追加し、3D 書式設定を適用します。カメラの回転値は度単位で、押し出し高さは 100 ポイントです。例はスライドを PNG 画像に 2 倍のサイズでレンダリングし、プレゼンテーションを PPTX として保存します。

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

レンダリングされたスライド画像は、矩形が厚い 3D ブロックとして表示されます：

![フロント面に白い 3D テキストがある、レンダリングされた青い 3D 四角形](img_01_01.png)

## **カメラでシェイプを回転**

PowerPoint では、3‑D 回転ペインから 3D 回転を設定します。X、Y、Z の回転値はカメラ API で設定する回転に対応します。

![PowerPoint 3‑D 回転ペインで X、Y、Z の回転値がハイライトされている画像](img_02_01.png)

Aspose.Slides では、[ThreeDFormat.camera](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/camera/) でカメラにアクセスします。この例は矩形を作成し、正射投影の正面ビューを選択し、X、Y、Z の回転をそれぞれ 20、30、40 度に設定します。ファイルを保存せずにメモリ内でシェイプを構成します：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

ビューアがオブジェクトを見る角度を変更したいときにカメラを使用します。これはスライド上の 2D シェイプジオメトリを変更せず、PowerPoint と Aspose.Slides がレンダリング時に使用する 3D 視点を変更します。

## **押し出しと深さの追加**

押し出しはシェイプを前面から後方に延長させ、厚みを与えます。PowerPoint では、深さコントロールがこの可視厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint の深さコントロールが押し出しの色と押し出し高さプロパティにマッピングされている画像](img_02_02.png)

厚さは [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/extrusion_height/) で、側面の色は [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/extrusion_color/) で設定します。この例は矩形に 100 ポイントの押し出しと紫色の側面を与え、カメラを回転させて厚みを確認します。ファイルを保存せずにメモリ内でシェイプを構成します：

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

[ThreeDFormat.depth](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/depth/) プロパティは 3D シェイプの深さを設定します。[extrusion_height](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/extrusion_height/) プロパティは押し出し効果の高さを制御します（この例を参照）。

## **3D 効果でグラデーションまたは画像塗りつぶしを使用**

3D 書式設定はシェイプの塗りつぶしとは独立しています。前面に単色、グラデーション、パターン、または画像塗りつぶしを適用しながら、同じカメラ、光、マテリアル、押し出し設定を使用できます。

この例は前面に青からオレンジへのグラデーションを、150 ポイントの押し出しには濃いオレンジ色を適用します。グラデーションの停止点は 0 と 100 が開始と終了を示します。カメラ回転値は度単位です。スライドは PNG 画像に 2 倍のサイズでレンダリングされます：

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

レンダリングされた出力は前面のグラデーションを保持し、押し出しは別個に描画されます：

![青からオレンジへのグラデーション塗りつぶしとオレンジの押し出しを持つ 3D 矩形のレンダリング画像](img_02_03.png)

画像塗りつぶしを使用する場合は、プレゼンテーションに画像を追加し、シェイプの塗りつぶしに割り当てます。この例は作業ディレクトリに "image.jpg" という名前の既存ファイルがあることを前提としています。画像を矩形全体に伸ばし、150 ポイントの押し出しと度単位のカメラ回転を設定します。ファイルを保存またはレンダリングせずにメモリ内でシェイプを構成します：

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

画像は前面に描画され、押し出しは 3D 側面としてレンダリングされます：

![前面に写真塗りつぶし、側面にオレンジの押し出しを持つ 3D 矩形のレンダリング画像](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響します。テキストの 3D 書式設定はテキスト フレームに影響します。これは文字自体に押し出し、マテリアル、照明、カメラ設定が必要な WordArt のような効果に便利です。

次の例はオレンジと白の格子パターンのテキストを作成し、上向きのアーチを適用し、[TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/three_d_format/) を通じて 3D 設定を構成します。押し出し高さと深さはポイント、光の回転は度単位です。シェイプの塗りつぶしと輪郭は非表示にし、テキストのみが見えるようにします。例は PNG 画像をスライドのデフォルトサイズの 2 倍でレンダリングし、プレゼンテーションを PPTX として保存します：

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

テキストは曲線状に押し出された 3D レタリングとしてレンダリングされます：

![アーチ状に変形した WordArt、オレンジのパターン塗りつぶし、暗い押し出しを持つ 3D テキストのレンダリング画像](img_02_05.png)

## **3D シェイプ上でテキストを平坦に保つ**

シェイプの 3D 外観を保ちつつテキストを読みやすくするには、[TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/keep_text_flat/) を [TextFrame.text_frame_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/text_frame_format/) から設定します。値が `True` の場合、テキストは 3D シーンから除外されます。`False` の場合、テキストはシーンに参加し、3D の向きに従います。

この設定はシェイプの 3D 書式設定（カメラ、照明、マテリアル、押し出し）を削除しません。また、通常の回転とは異なります。[Shape.rotation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/rotation/) はスライド平面でシェイプを回転させ、[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/rotation_angle/) はテキストのバウンディング ボックス内でのカスタム回転を制御します。テキストを 3D シーンから除外してもこれらの角度はリセットされません。

次のセルフコンテインド例は、青い矩形にテキストを付けてコピーし、元の隣に配置します。両方のシェイプは同じ 3D 書式設定を持ち、テキスト設定だけが異なります：左側は `False`、右側は `True`。カメラ角度は度単位、押し出し高さは 40 ポイントです。例はプレゼンテーションを PPTX として保存し、比較スライドを PNG に 2 倍サイズでレンダリングします。

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

左側はテキストが 3D 向きに従い、右側は平坦で読みやすくなります。両方の矩形は同じ可視的な押し出しと 3D 向きを保持しています。

![左側が False、右側が True の keep_text_flat 設定の違いを示す 3D 矩形の比較画像](keep_text_flat.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存すると 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスタライズまたは描画され、2D 結果として出力に組み込まれます。これはスライドを [PNG](/slides/ja/python-net/convert-powerpoint-to-png/) にレンダリングする場合、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/) にエクスポートする場合、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/) にエクスポートする場合、または [video conversion](/slides/ja/python-net/convert-powerpoint-to-video/) 用のフレームを生成する場合に適用されます。

以下の点に留意してください：

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。
- 最終的な外観は、カメラ、ライトリグ、マテリアル、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承されたまたはテーマベースの書式設定値を確認する必要がある場合は、[effective shape properties](/slides/ja/python-net/shape-effective-properties/) を読み取ります。
- 一部の出力フォーマットは、編集可能な PowerPoint 3D 書式設定を保存できません。そのようなフォーマットでは、視覚的結果がレンダリングされ、編集可能な 3D 設定としては保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプとテキストの PowerPoint 3D 効果を作成およびレンダリングします。エクスポートされた画像、PDF、HTML ページをインタラクティブな 3D シーンにして回転させることはできません。PPTX では、フォーマットがサポートしている限り、3D 書式設定は PowerPoint で編集可能なまま残ります。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は通常の PowerPoint シェイプまたはテキストに適用される書式設定で、回転、押し出し、ベベル、照明、マテリアルなどがあります。本記事は 3D 効果について説明しています。

**可視的な 3D シェイプに必要な設定は何ですか？**

最低限、カメラの回転と押し出しまたは深さを設定します。実際には、照明リグとマテリアルも設定して、レンダリングされた面に明確なハイライトと影を付けることが一般的です。

**シェイプとテキストの両方に 3D 効果を適用できますか？**

はい。シェイプ本体には [Shape.three_d_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/three_d_format/) を、テキストには [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/three_d_format/) を使用します。

**画像、PDF、HTML、またはビデオフレームにエクスポートしたときに 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。[Shape Effective Properties](/slides/ja/python-net/shape-effective-properties/) で説明されている有効書式設定 API を使用して、最終的なカメラ、ライトリグ、ベベル、その他の 3D 値を取得できます。