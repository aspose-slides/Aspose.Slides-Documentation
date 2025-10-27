---
title: Pythonで3Dプレゼンテーションを作成
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
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でインタラクティブな 3D プレゼンテーションを手軽に生成します。PowerPoint および OpenDocument 形式への高速エクスポートで汎用的に活用できます。"
---

## **概要**

通常、3D PowerPoint プレゼンテーションはどのように作成していますか？Microsoft PowerPoint では、3D モデルの追加、シェイプへの 3D 効果の適用、3D テキストの作成、3D グラフィックの挿入、3D アニメーションの構築が可能です。

3D 効果の作成は大きなインパクトを与え、標準的なスライドを 3D プレゼンテーションに変える最も簡単な方法です。Aspose.Slides 20.9 以降、**クロスプラットフォーム 3D エンジン**が追加されました。このエンジンにより、3D 効果を持つシェイプやテキストのエクスポートおよびラスタライズが可能になります。以前のバージョンでは 3D 効果を持つシェイプは平面で描画されていましたが、現在は **本格的な 3D** で描画できます。また、Aspose.Slides API を使用して 3D 効果を持つシェイプを作成することもできます。

Aspose.Slides API でシェイプを PowerPoint の 3D シェイプにするには、[Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) プロパティを使用します。このプロパティは [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat) クラスのメンバーを公開します。

- [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) と [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/)：ベベルを設定し、ベベルの種類（例: Angle、Circle、SoftRound）を選択し、ベベルの高さと幅を定義します。
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/)：オブジェクトの周囲をカメラが移動する様子をシミュレートします。カメラの回転、ズーム、その他のプロパティを調整することで、PowerPoint の 3D モデルのようにシェイプを操作できます。
- [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) と [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/)：輪郭プロパティを設定し、シェイプを 3D PowerPoint オブジェクトのように見せます。
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/)、[extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/)、[extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/)：深さを設定したり押し出したりしてシェイプを立体化します。
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/)：3D シェイプに照明効果を付与します。カメラと同様に、光の回転を 3D シェイプに対して設定し、光の種類を選択できます。
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/)：素材を選択して 3D シェイプをよりリアルにします。事前定義された素材には Metal、Plastic、Powder、Matte などがあります。

すべての 3D 機能はシェイプとテキストの両方に適用できます。以下のセクションでは、これらのプロパティへのアクセス方法と、段階的な使用例を示します。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")

    presentation.save("sandbox_3d.pptx", slides.export.SaveFormat.PPTX)
```

レンダリングされたサムネイルは次のようになります:

![todo:image_alt_text](img_01_01.png)

## **3D 回転**

PowerPoint の 3D シェイプは、三次元空間で回転させてインタラクティブ性を付加できます。PowerPoint で 3D シェイプを回転させるには、次のメニューを使用します:

![todo:image_alt_text](img_02_01.png)

Aspose.Slides API では、[camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) プロパティを介してシェイプの 3D 回転を制御します。

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... 他の 3D シーン パラメータを設定

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## **3D 奥行きと押し出し**

シェイプに第3の次元を加えて真の 3D にするには、[ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) と [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) プロパティを使用します:

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... 他の 3D シーン パラメータを設定

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

PowerPoint では通常、**Depth** メニューで 3D シェイプの奥行きを設定します:

![todo:image_alt_text](img_02_02.png)

## **3D グラデーション**

グラデーションは PowerPoint の 3D シェイプの塗りつぶしに使用できます。グラデーション塗りつぶしを持つシェイプを作成し、3D 効果を適用してみましょう:

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
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
   
    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

結果は次のとおりです:

![todo:image_alt_text](img_02_03.png)

グラデーション塗りだけでなく、画像でシェイプを塗りつぶすこともできます:

```py
with open("image.png", "rb") as image_file:
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... 3D 設定: shape.three_d_format.camera、shape.three_d_format.light_rig、shape.three_d_format.Extrusion* プロパティ

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

見た目は次のようになります:

![todo:image_alt_text](img_02_04.png)

## **3D テキスト (WordArt)**

Aspose.Slides ではテキストにも 3D 効果を適用できます。WordArt の変形効果を使用して 3D テキストを作成してみましょう:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D text"
   
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID
   
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128
   
    text_frame_format = shape.text_frame.text_frame_format
    # "Arch Up" WordArt 変形効果を設定
    text_frame_format.transform = slides.TextShapeType.ARCH_UP

    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
   
    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text3d.png")

    presentation.save("text3d.pptx", slides.export.SaveFormat.PPTX)
```

結果は以下のとおりです:

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**プレゼンテーションを画像/PDF/HTML にエクスポートしたとき、3D 効果は保持されますか？**

はい。Slides の 3D エンジンは、サポートされている形式へのエクスポート時に 3D 効果をレンダリングします（[画像](/slides/ja/python-net/convert-powerpoint-to-png/)、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/) など）。

**テーマや継承などを考慮した「有効な」3D パラメータ値を取得できますか？**

はい。Slides は [有効な値を読み取る](/slides/ja/python-net/shape-effective-properties/) API を提供しており、3D（照明、ベベルなど）に関しても最終的に適用された設定を確認できます。

**プレゼンテーションをビデオに変換するとき、3D 効果は機能しますか？**

はい。ビデオ用フレームを [生成](/slides/ja/python-net/convert-powerpoint-to-video/)する際、3D 効果は [エクスポートされた画像](/slides/ja/python-net/convert-powerpoint-to-png/) と同様にレンダリングされます。