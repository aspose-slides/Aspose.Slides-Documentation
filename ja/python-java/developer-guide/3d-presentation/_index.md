---
title: Python を使用してプレゼンテーションに 3D 効果を作成する
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
description: "Aspose.Slides を使用して、Java 経由の Python で PowerPoint のシェイプとテキストに 3D 効果を適用およびレンダリングします。カメラ、照明、素材、押し出し、塗りつぶし、3D テキストを設定します。"
---
## **概要**

Aspose.Slides for Python via Java は、シェイプやテキストに対して PowerPoint 形式の 3D 書式設定を作成、編集、保持、レンダリングできます。本記事では、回転、押し出し、ベベル、照明、素材、グラデーションまたは画像塗りつぶし、そして 3D テキストといった 3D 効果について説明します。

{{% alert color="info" title="注意" %}}
この記事は PowerPoint のシェイプおよびテキストに対する 3D 書式設定効果について扱います。スタンドアロンの 3D モデル ファイルの挿入や編集については対象外です。スライドを画像、PDF、または HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

[Installation](/slides/ja/python-java/installation/) に記載された手順でパッケージをインストールします。各例では `asposeslides` をインポートし、必要に応じて JVM を起動し、API をインポートします。画像塗りつぶしの例は、作業ディレクトリに `image.jpg` が存在する必要があります。

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには [Shape.getThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getThreeDFormat) を使用します。返されるフォーマット オブジェクトはそのシェイプの 3D シーンを制御します。

テキストの場合は [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#getThreeDFormat) を使用します。これによりシェイプ本体ではなくテキストフレームに 3D 書式設定が適用されます。

主要な API メンバーは次のとおりです。

| API メンバー | 制御内容 | 使用タイミング |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getCamera) | 視点、プリセット カメラ タイプ、回転、ズーム、遠近感。 | 3D 空間でオブジェクトを回転させる、または PowerPoint の 3D 回転プリセットに合わせる場合。 |
| [getLightRig](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getLightRig) | ライト プリセット、方向、ライトの回転。 | 3D 表面上のハイライトや影の見え方を変更する場合。 |
| [getMaterial](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getMaterial) と [setMaterial](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#setMaterial) | フラット、マット、プラスチック、金属などの表面素材。 | 同じ形状をより平坦、柔らか、光沢、または金属的に見せたい場合。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getExtrusionHeight) と [setExtrusionHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#setExtrusionHeight) | 前面から後方にどれだけ形状が伸びるか。 | 平面のシェイプを視覚的に厚みのある 3D オブジェクトに変換する場合。 |
| [getExtrusionColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getExtrusionColor) | 押し出された側面の色。 | 奥行きを可視化したり、側面の色を前面の塗りつぶしと合わせたりする場合。 |
| [getDepth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getDepth) と [setDepth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint の 3D 書式設定で使用される追加の奥行き。 | シェイプやテキストの奥行きを微調整したい場合。特にベベルや素材設定と組み合わせると効果的です。 |
| [getBevelTop](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getBevelTop) と [getBevelBottom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getBevelBottom) | 前面と背面のエッジの隆起または丸み。 | 鋭利な平面ではなく、柔らかく成形されたエッジを追加したい場合。 |
| [getContourColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getContourColor)、[getContourWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getContourWidth) と [setContourWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#setContourWidth) | 3D オブジェクトの輪郭線。 | レンダリング結果でオブジェクトの境界を強調したい場合。 |

## **3D シェイプの作成**

シェイプが説得的に 3D に見えるようになるには、通常次の 4 種類の設定が必要です。

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れてしまうことがあります。  
- ライト設定：照明が面や側面の可読性を向上させます。  
- 素材設定：表面素材が光の反射方法に影響します。  
- 押し出しまたは奥行き設定：平面のシェイプに厚みを与えるために必要です。

次の例は長方形を作成し、正面にテキストを追加し、3D 書式設定を適用してプレゼンテーションを PPTX として保存し、スライドを PNG 画像としてレンダリングします。

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

レンダリングされたスライド画像は、長方形が厚みのある 3D ブロックとして表示されています。

![正面に白い3Dテキストがある青い3D長方形のレンダリング](img_01_01.png)

## **カメラでシェイプを回転**

PowerPoint では、3-D 回転ペインから 3D 回転を設定します。X、Y、Z の回転値はカメラ API で設定する回転に対応します。

![X、Y、Z の回転値が強調表示された PowerPoint の 3D 回転ペイン](img_02_01.png)

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

ビューアがオブジェクトを見る角度を変更したいときにカメラを使用します。これはスライド上の 2D シェイプジオメトリを変更するものではなく、PowerPoint および Aspose.Slides がレンダリング時に使用する 3D 視点を変更します。

## **押し出しと奥行きを追加**

押し出しはシェイプの前面の背後に延長させることで厚みを表現します。PowerPoint では、奥行きコントロールがこの可視厚さを決定し、カラー コントロールが側面の色を決めます。

![PowerPoint の奥行きコントロールが押し出しカラーと押し出し高さプロパティにマップされている様子](img_02_02.png)

厚みには押し出し高さを、側面の色には押し出しカラーを設定します。

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

PowerPoint の奥行き値を直接操作したい場合や、奥行きをベベル、素材、テキスト効果と組み合わせたい場合に depth 設定を使用します。多くのシェイプシナリオでは、押し出し高さの方が可視的な押し出しを直接表現できるため、より分かりやすい設定となります。

## **3D 効果と組み合わせたグラデーションまたは画像塗りつぶしの使用**

3D 書式設定はシェイプの塗りつぶしとは独立しています。正面に単色、グラデーション、パターン、または画像塗りつぶしを適用しながら、同じカメラ、ライト、素材、押し出し設定を使用できます。

この例はシェイプにグラデーション塗りつぶしを適用し、側面には濃い押し出しカラーを設定します。

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

レンダリング結果は正面にグラデーションを保持し、押し出しを別個に描画します。

![青からオレンジへのグラデーション塗りつぶしとオレンジの押し出しを持つ 3D 長方形のレンダリング](img_02_03.png)

画像塗りつぶしを使用する場合は、プレゼンテーションに画像を追加してシェイプの塗りつぶしに割り当てます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

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

画像は正面にレンダリングされ、押し出しは 3D 側面として描画されます。

![正面に写真塗りつぶし、側面にオレンジの押し出しを持つ 3D 長方形のレンダリング](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響しますが、テキストの 3D 書式設定はテキストフレームに影響します。文字自体に押し出し、素材、照明、カメラ設定が必要な WordArt のような効果に便利です。

次の例はパターン塗りつぶしのテキストを作成し、WordArt 変形を適用し、[TextFrameFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/) の 3D 設定を構成します。

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

テキストはアーチ状に曲げられ、押し出された 3D 文字としてレンダリングされます。

![アーチ状の WordArt 変形、オレンジのパターン塗りつぶし、暗い押し出しを持つ 3D テキストのレンダリング](img_02_05.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する場合、3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする際は、3D シーンがラスター化または 2D 結果として描画されます。これはスライドを PNG にレンダリングする、PDF にエクスポートする、HTML にエクスポートする、またはビデオ変換用のフレームを生成する場合に適用されます。

留意点は次のとおりです。

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にオブジェクトを回転させることはできません。  
- 最終的な外観はカメラ、ライト リグ、素材、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。  
- 継承された値やテーマベースの書式設定値を確認したい場合は、effective formatting API を使用してください。  
- 一部の出力形式は編集可能な PowerPoint 3D 書式設定を保持できません。そのような形式では、視覚結果がレンダリングされ、編集可能な 3D 設定としては保存されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプやテキストの PowerPoint 3D 効果を作成およびレンダリングしますが、エクスポートされた画像、PDF、HTML ページを回転させられるインタラクティブな 3D シーンにすることはできません。PPTX 形式では、フォーマットがサポートしている限り、3D 書式設定は PowerPoint で編集可能なまま残ります。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は通常の PowerPoint シェイプまたはテキストに適用される書式設定で、回転、押し出し、ベベル、照明、素材などが含まれます。本稿は 3D 効果について取り上げています。

**視覚的に見える 3D シェイプに必要な設定は何ですか？**

最低限、カメラの回転と押し出しまたは奥行きを設定します。実務では、ハイライトとシャドウを明確にするためにライト リグと素材も設定するのが一般的です。

**シェイプとテキストの両方に 3D 効果を適用できますか？**

はい。シェイプ本体には [Shape.getThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getThreeDFormat) を、テキストには [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#getThreeDFormat) を使用します。

**画像、PDF、HTML、ビデオフレームへのエクスポート時に 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、およびビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力はレンダリングされた外観を含みますが、編集可能な 3D オブジェクトは含みません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getEffective) を使用して、最終的なカメラ、ライト リグ、ベベル、その他の 3D 値を取得できます。