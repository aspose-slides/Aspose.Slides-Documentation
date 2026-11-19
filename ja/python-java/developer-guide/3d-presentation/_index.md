---
title: Python を使用したプレゼンテーションでの 3D 効果の作成
linktitle: 3D プレゼンテーション
type: docs
weight: 232
url: /ja/python-java/3d-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Java 経由の Python で PowerPoint のシェイプとテキストに 3D 効果を適用およびレンダリングします。カメラ、照明、素材、押し出し、塗り、3D テキストを設定します。"
---
## **概要**

Aspose.Slides for Python via Java は、シェイプとテキストに対して PowerPoint スタイルの 3D 書式設定を作成、編集、保存、レンダリングできます。本記事では、回転、押し出し、ベベル、照明、素材、グラデーションまたは画像塗り、3D テキストなどの 3D 効果について説明します。

{{% alert color="info" title="Note" %}}
この記事は、PowerPoint のシェイプおよびテキストに対する 3D 書式設定効果について説明しています。単体の 3D モデルファイルの挿入や編集に関するものではありません。スライドを画像、PDF、または HTML にエクスポートすると、Aspose.Slides はこれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには、[Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) メソッドを使用します。このメソッドは [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) を返し、そのシェイプの 3D シーンを制御します。

テキストの場合は、[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) メソッドを使用します。これにより、シェイプ本体ではなくテキストフレームに 3D 書式設定が適用されます。

最も重要な API メンバーは次のとおりです：

| API メンバー | 制御内容 | 使用タイミング |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | 視点、プリセットカメラタイプ、回転、ズーム、および遠近感。 | オブジェクトを 3D 空間で回転させるか、PowerPoint の 3D 回転プリセットに合わせます。 |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | ライトのプリセット、方向、光の回転。 | 3D 表面上のハイライトと影の表示方法を変更します。 |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) と [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | フラット、マット、プラスチック、金属などの表面素材。 | 同じ形状をより平坦に、柔らかく、光沢的に、金属的に見せます。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) と [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | シェイプが前面からどれだけ後方に伸びるか。 | 平面のシェイプを見た目に厚い 3D オブジェクトに変換します。 |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | 押し出された側面の色。 | 奥行きを可視化したり、側面の色を前面の塗りと合わせたりします。 |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) と [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint の 3D 書式設定で使用される追加の 3D 奥行き。 | シェイプやテキストの奥行きを微調整します。特にベベルや素材設定と組み合わせる場合に有効です。 |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) と [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | 前面と背面のエッジが上向きまたは丸みを帯びた形状。 | 鋭い平面の代わりに、柔らかいまたは成形されたエッジを追加します。 |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) と [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) と [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | 3D オブジェクトの輪郭線。 | レンダリング出力でオブジェクトの境界を強調します。 |

## **3D シェイプの作成**

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れる可能性があるため。
- 光設定：照明により面や側面が見やすくなるため。
- 素材設定：表面が光の描画に影響するため。
- 押し出しまたは奥行き設定：平面のシェイプに厚みを持たせるため。

以下の例は矩形を作成し、前面にテキストを追加して 3D 書式設定を適用します。カメラ回転値は度数で、押し出し高さは 100 ポイントです。例ではスライドをデフォルトサイズの 2 倍の PNG 画像にレンダリングし、プレゼンテーションを PPTX として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

レンダリングされたスライド画像は、矩形が厚い 3D ブロックとして表示されます：

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **カメラでシェイプを回転させる**

PowerPoint では、3D 回転は「3-D 回転」ペインで設定します。X、Y、Z の回転値はカメラ API で設定する回転に対応しています。

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Aspose.Slides では、[ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) を介してカメラにアクセスします。この例は矩形を作成し、正投影の正面ビューを選択し、X、Y、Z の回転をそれぞれ 20、30、40 度に設定します。ファイルに保存せずメモリ上でシェイプを構成します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

ビューアがオブジェクトを見る視点を変更したいときにカメラを使用します。スライド上の 2D シェイプジオメトリは変更されません。PowerPoint および Aspose.Slides がレンダリング時に使用する 3D 視点が変更されます。

### **テンプレートシェイプからカメラの向きをコピーする**

テンプレートシェイプの向きを合わせるには、[Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) でカメラのプリセットを取得し、[Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation) で回転角度を取得します。この例では `template.pptx` を開き、最初のスライドの最初のシェイプから 2 番目のシェイプへカメラの向きをコピーします。両方のシェイプは既に 3D 照明が設定されており、2 番目のシェイプには明示的なカメラ回転がありません。

角度は度数です。インデックス `0` が緯度、`1` が経度、`2` が回転を表します。この順序で [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) に渡します。ソースが `None` を返す場合は明示的な回転が設定されていないので、2 番目のシェイプの角度は設定しません。`(0, 0, 0)` の明示的な回転は 3 つのゼロを返すため、コピーすべきです。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`camera-copy.pptx` を PowerPoint で再度開くと、右側の矢印は左側の矩形と同じカメラプリセットと回転を持ちます。両シェイプは同じ照明と押し出し深さを使用しています。

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **押し出しと奥行きの追加**

押し出しは、前面から背面へシェイプを伸ばすことで厚みを持たせます。PowerPoint では、奥行きコントロールがこの可視厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

[ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) を使用して厚さを設定し、[ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) で側面の色を取得します。この例では矩形に 100 ポイントの押し出しと紫の側面を付け、カメラを回転させて厚さを確認しています。ファイルに保存せずメモリ上でシェイプを構成します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) メソッドは 3D シェイプの奥行きを設定します。[setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) メソッドは、此の例に示すように、押し出し効果の高さを制御します。

## **3D 効果とともにグラデーションまたは画像塗りを使用する**

3D 書式設定はシェイプの塗りとは独立しています。前面に単色、グラデーション、パターン、または画像塗りを適用しても、同じカメラ、光、素材、押し出し設定を使用できます。

この例では、前面に青からオレンジへのグラデーションを、150 ポイントの押し出し側面に濃いオレンジ色を適用します。グラデーションの停止点は 0 と 100 で、開始と終了を示します。カメラ回転値は度数です。スライドはデフォルトサイズの 2 倍の PNG 画像にレンダリングされます：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

レンダリングされた出力は、前面のグラデーションを保持し、押し出しを別にレンダリングします：

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

代わりに画像塗りを使用するには、画像をプレゼンテーションに追加し、シェイプの塗りに割り当てます。この例では作業ディレクトリに "image.jpg" という名前のファイルが存在する必要があります。画像を矩形全体に伸ばし、150 ポイントの押し出しを適用し、カメラ回転を度数で設定します。ファイルに保存したりレンダリングしたりせずにメモリ上でシェイプを構成します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

画像は前面にレンダリングされ、押し出しは 3D 側面としてレンダリングされます：

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響し、テキストの 3D 書式設定はテキストフレームに影響します。文字自体に押し出し、素材、照明、カメラ設定が必要な WordArt のような効果に便利です。

以下の例は、オレンジと白の格子パターンのテキストを作成し、上向きのアーチを適用し、[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) を介して 3D 設定を構成します。押し出し高さと奥行きはポイント単位、光の回転は度数です。シェイプの塗りと輪郭は非表示にし、テキストのみが可視になるようにします。例ではデフォルトスライドサイズの 2 倍の PNG 画像をレンダリングし、プレゼンテーションを PPTX として保存します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

テキストは曲がった押し出し 3D 文字としてレンダリングされます：

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **3D シェイプ上でテキストを平面のまま保つ**

シェイプの 3D 外観を保ちつつテキストを読みやすくするには、[TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat) を経由して [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) を呼び出します。値が `True` の場合、テキストは 3D シーンから除外されます。`False` の場合、テキストはシーンに参加し、3D の向きに従います。

この設定はシェイプの 3D 書式設定（カメラ、照明、素材、押し出し）を削除しません。これらは [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) を通じて設定されたままです。また、通常の回転とは異なります。[Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) はスライド平面上でシェイプを回転させ、[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) はテキストのバウンディングボックス内でのカスタム回転を制御します。テキストを 3D シーンから除外しても、これらの角度はリセットされません。

以下の自己完結型の例は、テキスト付きの青い矩形を作成し、元の横にクローンします。両シェイプは同じ 3D 書式設定を持ち、テキスト設定だけが異なります：左側は `False`、右側は `True`。カメラ角度は度数、押し出し高さは 40 ポイントです。例ではプレゼンテーションを PPTX として保存し、比較スライドをデフォルトサイズの 2 倍の PNG にレンダリングします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

左側ではテキストが 3D の向きに従います。右側では平面のままで読みやすくなります。両矩形は同じ可視の押し出しと 3D の向きを保持しています。

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスタライズされ、2D 結果として出力に描画されます。これは、スライドを [PNG](/slides/ja/python-java/convert-powerpoint-to-png/) にレンダリングする、[PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/) にエクスポートする、[HTML](/slides/ja/python-java/convert-powerpoint-to-html/) にエクスポートする、または [video conversion](/slides/ja/python-java/convert-powerpoint-to-video/) 用のフレームを生成する場合にも適用されます。

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。
- 最終的な外観はカメラ、光源、素材、押し出し、塗り、スライドのスケーリングの組み合わせに依存します。
- 継承された値やテーマベースの書式設定値を確認する必要がある場合は、[有効なシェイプ プロパティ](/slides/ja/python-java/shape-effective-properties/) を参照してください。
- 一部の出力形式では、編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、視覚的な結果はレンダリングされ、編集可能な 3D 設定として保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプとテキストの PowerPoint 3D 効果を作成およびレンダリングしますが、エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはありません。PPTX 形式では、フォーマットがサポートしている限り、PowerPoint 内で 3D 書式設定は編集可能なままです。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は、シェイプやテキストに対して適用される書式設定で、回転、押し出し、ベベル、照明、素材などを含みます。本記事は 3D 効果について解説しています。

**見える 3D シェイプに必要な設定は何ですか？**

最低でもカメラ回転と押し出しまたは奥行きを設定する必要があります。実際には、レンダリングされた面に明瞭なハイライトと影を付けるために、光源と素材も設定します。

**シェイプとテキストの両方に 3D 効果を適用できますか？**

はい。シェイプ本体には [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) を、テキストには [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) を使用します。

**画像、PDF、HTML、ビデオフレームへエクスポートするときに 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承とテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。[シェイプの有効プロパティ](/slides/ja/python-java/shape-effective-properties/) で説明されている有効な書式設定 API を使用して、最終的なカメラ、光源、ベベル、その他の 3D 値を取得できます。