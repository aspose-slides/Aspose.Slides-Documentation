---
title: Pythonで3Dプレゼンテーションを作成
linktitle: 3Dプレゼンテーション
type: docs
weight: 232
url: /ja/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3Dプレゼンテーション
- 3D回転
- 3D奥行き
- 3D押し出し
- 3Dグラデーション
- 3Dテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して、Python でインタラクティブな 3D プレゼンテーションを手軽に生成できます。PowerPoint および OpenDocument 形式へ迅速にエクスポートし、幅広い用途に活用できます。"
---

## 概要
通常、どのようにして 3D PowerPoint プレゼンテーションを作成しますか？
Microsoft PowerPoint は、3D モデルを追加したり、図形に 3D 効果を適用したり、3D テキストを作成したり、プレゼンテーションに 3D グラフィックスをアップロードしたり、PowerPoint 3D アニメーションを作成したりすることができる3D プレゼンテーションの作成を可能にします。

3D 効果を作成することで、プレゼンテーションを 3D プレゼンテーションに改善する大きな影響があり、最も簡単に 3D プレゼンテーションを実装できる方法かもしれません。
Aspose.Slides 20.9 バージョン以降、***クロスプラットフォーム 3D エンジン***が追加されました。この新しい 3D エンジンは、
3D 効果を持つ図形やテキストをエクスポートしてラスタライズすることができます。以前のバージョンでは、
3D 効果が適用されたスライドの図形は平面としてレンダリングされていました。しかし、今では***本格的な 3D***として
図形をレンダリングすることが可能です。
さらに、今では Slides の公開 API を介して 3D 効果を持つ図形を作成することができます。

Aspose.Slides API では、
図形を PowerPoint の 3D 図形にするには、[IShape.ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) プロパティを使用し、
その機能は [IThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat) インターフェイスから継承されます：
- [BevelBottom](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
および [BevelTop](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): 図形にベベルを設定し、ベベルのタイプを定義します（例: Angle, Circle, SoftRound）、ベベルの高さと幅を定義します。
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): オブジェクトの周りでカメラの動きを模倣するために使用されます。つまり、カメラの回転、ズーム、およびその他のプロパティを設定することで、 
あなたの図形を PowerPoint の 3D モデルのように操作できます。
- [ContourColor](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
および [ContourWidth](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): 3D PowerPoint 図形のように見えるようにするための輪郭プロパティを設定します。
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/), 
[extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
および [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): 図形を三次元にするために使用します。これは、2D 図形を 3D 図形に変換することを意味し、
その深さを設定したり押し出したりします。
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): 3D 図形に光の効果を作成することができます。このプロパティの論理は Camera に近く、3D 図形に対する照明の回転を設定し、
光のタイプを選択します。
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): 3D 図形の素材のタイプを設定することで、よりリアルな効果を与えることができます。このプロパティは、以下のような一連のプレデファインされた素材を提供します： 
金属、プラスチック、粉末、マットなど。

すべての 3D 機能は、図形とテキストの両方に適用できます。上に述べたプロパティにアクセスする方法を見てから、一歩ずつ詳細に見ていきましょう：
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

レンダリングされたサムネイルは次のようになります：

![todo:image_alt_text](img_01_01.png)

## 3D 回転
PowerPoint の 3D 図形を 3D 平面で回転させることが可能で、これによりよりインタラクティブになります。PowerPoint で 3D 図形を回転させるには、通常は次のメニューを使用します：

![todo:image_alt_text](img_02_01.png)

Aspose.Slides API では、3D 図形の回転を [camera](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) プロパティを使用して管理できます：

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... 他の 3D シーンパラメータを設定

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## 3D 深度と押し出し
形状に第3の次元を追加し、3D 図形にするには、[IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
および [extrusion_color.color](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) プロパティを使用します：

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... 他の 3D シーンパラメータを設定

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

通常、PowerPoint で 3D 図形の深度を設定するためには、深度メニューを使用します：

![todo:image_alt_text](img_02_02.png)


## 3D グラデーション
グラデーションは、PowerPoint の 3D 図形の色を塗りつぶすために使用できます。グラデーション塗りの色を持つ図形を作成し、3D 効果を適用してみましょう：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.text_frame.text = "3D グラデーション"
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

そして、こちらが結果です：

![todo:image_alt_text](img_02_03.png)

グラデーション塗りの色のほか、画像で図形を塗りつぶすことも可能です：
```py
with open("image.png", "rb") as image_file: 
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... 3D を設定: shape.three_d_format.camera, shape.three_d_format.light_rig, shape.three_d_format.Extrusion* プロパティ

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```


それがこちらです：

![todo:image_alt_text](img_02_04.png)

## 3D テキスト (WordArt)
Aspose.Slides は、テキストにも 3D を適用することを許可します。3D テキストを作成するには、WordArt 変換効果を使用できます：

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
    shape.text_frame.text = "3D テキスト"
   
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID
   
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128
   
    text_frame_format = shape.text_frame.text_frame_format
    # "アーチアップ" WordArt 変換効果を設定
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

こちらが結果です：

![todo:image_alt_text](img_02_05.png)


## サポートされていない - 近日公開
次の PowerPoint 3D 機能はまだサポートされていません：
- ベベル
- 材料
- 輪郭
- 照明

私たちは 3D エンジンを改善し続けており、これらの機能はさらに実装される予定です。