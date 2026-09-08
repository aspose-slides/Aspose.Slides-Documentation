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
description: "Aspose.Slides を使用して、Python（Java 経由）で PowerPoint のシェイプとテキストに 3D 効果を適用およびレンダリングします。カメラ、照明、素材、押し出し、塗りつぶし、3D テキストを構成します。"
---
## **概要**

Aspose.Slides for Python via Java は、シェイプとテキストに対して PowerPoint 形式の 3D 書式設定を作成、編集、保持、レンダリングできます。本記事では、回転、押し出し、ベベル、照明、素材、グラデーションまたは画像塗りつぶし、そして 3D テキストといった 3D 効果について説明します。

{{% alert color="info" title="Note" %}}
この文書は PowerPoint のシェイプとテキストに対する 3D 書式設定効果について説明しています。単独の 3D モデル ファイルの挿入や編集については取り上げていません。スライドを画像、PDF、または HTML にエクスポートすると、Aspose.Slides はこれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

パッケージは [Installation](/slides/ja/python-java/installation/) に記載された手順でインストールしてください。各サンプルは `asposeslides` をインポートし、必要に応じて JVM を起動し、API をインポートします。画像塗りつぶしの例では、作業ディレクトリに `image.jpg` ファイルが必要です。

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには、[Shape.getThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getThreeDFormat) を使用します。返されるフォーマット オブジェクトがそのシェイプの 3D シーンを制御します。

テキストの場合は、[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#getThreeDFormat) を使用します。これにより、シェイプ本体ではなくテキスト フレームに 3D 書式設定が適用されます。

最も重要な API メンバーは次のとおりです。

| API メンバー | 制御内容 | 使用シーン |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getCamera) | 視点、プリセット カメラ タイプ、回転、ズーム、遠近法。 | 3D 空間でオブジェクトを回転させるか、PowerPoint の 3D 回転プリセットに合わせる場合。 |
| [getLightRig](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getLightRig) | ライト プリセット、方向、ライト回転。 | 3D 表面上のハイライトや影の表示方法を変更する場合。 |
| [getMaterial](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getMaterial) と [setMaterial](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#setMaterial) | フラット、マット、プラスチック、金属などの表面素材。 | 同じジオメトリをより平坦、柔らか、光沢、金属的に見せる場合。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getExtrusionHeight) と [setExtrusionHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#setExtrusionHeight) | シェイプが前面からどれだけ後方に延びるか。 | 平面シェイプを目に見える厚みのある 3D オブジェクトに変換する場合。 |
| [getExtrusionColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getExtrusionColor) | 押し出し側面の色。 | 奥行きを視覚化したり、前面の塗りつぶしと側面の色を合わせる場合。 |
| [getDepth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getDepth) と [setDepth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint の 3D 書式設定で使用される追加の奥行き。 | ベベルや素材設定と組み合わせて、シェイプやテキストの奥行きを微調整する場合。 |
| [getBevelTop](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getBevelTop) と [getBevelBottom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getBevelBottom) | 前面と背面のエッジに対する隆起または丸み。 | 鋭い平面ではなく、柔らかく成形されたエッジを追加する場合。 |
| [getContourColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getContourColor)、[getContourWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getContourWidth) と [setContourWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#setContourWidth) | 3D オブジェクトの輪郭線。 | レンダリング結果でオブジェクトの境界を強調したい場合。 |

## **3D シェイプを作成する**

シェイプが説得力のある 3D に見えるようになるには、通常次の 4 種類の設定が必要です。

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れてしまうことがあるため。
- ライト設定：照明により面と側面が読みやすくなるため。
- 素材設定：表面が光の当たり方に影響するため。
- 押し出しまたは奥行き設定：平面シェイプに厚みを持たせるため。

以下の例は矩形を作成し、前面にテキストを追加し、3D 書式設定を適用し、プレゼンテーションを PPTX として保存し、スライドを PNG 画像としてレンダリングします。

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

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

レンダリングされたスライド画像は、矩形が厚みのある 3D ブロックとして表示されます。

![前面に白色の 3D テキストがある青い 3D 矩形のレンダリング画像](img_01_01.png)

## **カメラでシェイプを回転させる**

PowerPoint では、3‑D 回転ペインで回転が設定されます。X、Y、Z の回転値はカメラ API で設定する回転に対応しています。

![X、Y、Z の回転値がハイライトされた PowerPoint の 3‑D 回転ペイン](img_02_01.png)

Aspose.Slides では、[Shape.getThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getThreeDFormat) が返す 3D フォーマットを介してカメラ タイプと回転を設定します。

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

ビューアがオブジェクトを見る視点を変更したいときにカメラを使用します。スライド上の 2D シェイプ ジオメトリは変更されません。PowerPoint と Aspose.Slides がレンダリング時に使用する 3D 視点が変わります。

## **押し出しと奥行きを追加する**

押し出しはシェイプを前面から後方に延長させ、厚みを持たせます。PowerPoint では奥行きコントロールがこの可視厚みを決定し、色コントロールが側面の色を決めます。

![奥行きコントロールが押し出しの色と高さプロパティにマッピングされた PowerPoint の画面](img_02_02.png)

厚みには押し出し高さ、側面の色には押し出し色を設定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

PowerPoint の奥行き値を直接操作したい場合や、ベベル、素材、テキスト効果と組み合わせて奥行きを使用したい場合に depth 設定を使用します。多くのシェイプ シナリオでは、押し出し高さの方が可視的な押し出しを直接表現するため分かりやすいです。

## **3D 効果と共にグラデーションまたは画像塗りつぶしを使用する**

3D 書式設定はシェイプの塗りつぶしとは独立しています。前面に単色、グラデーション、パターン、または画像塗りつぶしを適用しつつ、同じカメラ、ライト、素材、押し出し設定を使用できます。

この例はシェイプにグラデーション塗りつぶしを適用し、側面には暗めの押し出し色を設定します。

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

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

レンダリング結果は前面にグラデーションが残り、押し出しは別個に描画されます。

![青からオレンジへのグラデーション塗りつぶしとオレンジの押し出しを持つ 3D 矩形のレンダリング画像](img_02_03.png)

画像塗りつぶしを使用する場合は、画像をプレゼンテーションに追加し、シェイプの塗りつぶしに割り当てます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
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
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

画像は前面にレンダリングされ、押し出しは 3D 側面として描画されます。

![前面に写真塗りつぶし、側面にオレンジの押し出しを持つ 3D 矩形のレンダリング画像](img_02_04.png)

## **テキストに 3D 書式設定を適用する**

シェイプの 3D 書式設定はシェイプ本体に影響し、テキストの 3D 書式設定はテキスト フレームに影響します。文字自体に押し出し、素材、照明、カメラ設定が必要な WordArt のような効果に便利です。

以下の例はパターン塗りつぶしのテキストを作成し、WordArt 変形を適用し、[TextFrameFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/) に 3D 設定を構成します。

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

テキストは曲線状に押し出された 3D 文字としてレンダリングされます。

![アーチ状の WordArt 変形、オレンジのパターン塗りつぶし、暗い押し出しを持つ 3D テキストのレンダリング画像](img_02_05.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスタライズされ、2D の結果として出力に描画されます。これは PNG へのスライドレンダリング、PDF へのエクスポート、HTML へのエクスポート、またはビデオ変換用フレームの生成時に適用されます。

留意点：

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。
- 最終的な外観はカメラ、ライトリグ、素材、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承された設定やテーマベースの書式設定値を確認したい場合は、Effective Formatting API を使用してください。
- 一部の出力形式は編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、視覚的結果は 3D 設定として保持されるのではなく、レンダリングされた画像として保存されます。

## **よくある質問**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプとテキストに対する PowerPoint の 3D 効果を作成およびレンダリングしますが、エクスポートされた画像、PDF、HTML ページをインタラクティブな 3D シーン（ビューアが回転できる）にすることはできません。PPTX では、フォーマットが対応している場合に 3D 書式設定は PowerPoint で編集可能なまま残ります。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は通常の PowerPoint シェイプやテキストに対して適用される書式設定で、回転、押し出し、ベベル、照明、素材などが含まれます。本記事は 3D 効果について扱っています。

**見える 3D シェイプに必要な設定は何ですか？**

最低限、カメラの回転と押し出しまたは奥行きを設定します。実務では、ライトリグと素材も設定して、レンダリングされた面に明確なハイライトと影を付けることが一般的です。

**シェイプとテキストの両方に 3D 効果を適用できますか？**

はい。シェイプ本体には [Shape.getThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getThreeDFormat) を使用し、テキストには [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#getThreeDFormat) を使用します。

**画像、PDF、HTML、またはビデオフレームへエクスポートしたときに 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。最終的なカメラ、ライトリグ、ベベル、その他 3D 値を取得するには、[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getEffective) を使用してください。