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
description: "Aspose.Slides を使用して、Python via Java で PowerPoint の図形とテキストに 3D 効果を適用およびレンダリングします。カメラ、照明、素材、押し出し、塗りつぶし、3D テキストを設定します。"
---
## **概要**

Aspose.Slides for Python via Java は、図形やテキストに対して PowerPoint 形式の 3D 書式設定を作成、編集、保持、レンダリングできます。本記事では、回転、押し出し、ベベル、照明、素材、グラデーションまたは画像塗りつぶし、そして 3D テキストといった 3D 効果について説明します。

{{% alert color="info" title="Note" %}}
この記事は PowerPoint の図形とテキストに対する 3D 書式設定効果について説明しています。単独の 3D モデル ファイルの挿入や編集については取り扱いません。スライドを画像、PDF、または HTML にエクスポートする際、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

パッケージは [インストール](/slides/ja/python-java/installation/) に記載されている手順でインストールしてください。各例では `asposeslides` をインポートし、必要に応じて JVM を起動し、API をインポートします。画像塗りつぶしの例では、作業ディレクトリに `image.jpg` ファイルが必要です。

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには、[Shape.getThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getThreeDFormat) を使用します。返されるフォーマット オブジェクトは、そのシェイプの 3D シーンを制御します。

テキストの場合は、[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#getThreeDFormat) を使用します。これにより、シェイプ本体ではなくテキストフレームに 3D 書式設定が適用されます。

最も重要な API メンバーは次のとおりです：

| API メンバー | 制御対象 | 使用するタイミング |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getCamera) | 視点、プリセット カメラ タイプ、回転、ズーム、およびパースペクティブ。 | オブジェクトを 3D 空間で回転させる、または PowerPoint の 3D 回転プリセットに合わせる。 |
| [getLightRig](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getLightRig) | ライトのプリセット、方向、光の回転。 | 3D 表面上のハイライトと影の表示方法を変更する。 |
| [getMaterial](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getMaterial) と [setMaterial](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#setMaterial) | 平面、マット、プラスチック、金属などの表面素材。 | 同じジオメトリをより平坦、柔らか、光沢、または金属性に見せる。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getExtrusionHeight) と [setExtrusionHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#setExtrusionHeight) | シェイプが正面からどれだけ後方に伸びるか。 | 平面のシェイプを視覚的に厚みのある 3D オブジェクトに変換します。 |
| [getExtrusionColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getExtrusionColor) | 押し出された側面の色。 | 奥行きを可視化したり、側面の色を前面の塗りつぶしと調和させます。 |
| [getDepth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getDepth) と [setDepth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint の 3D 書式設定で使用される追加の 3D 深さ。 | シェイプやテキストの深さを微調整します。特にベベルや素材設定と組み合わせる際に有用です。 |
| [getBevelTop](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getBevelTop) と [getBevelBottom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getBevelBottom) | 正面と背面の面に突起または丸みを帯びたエッジ。 | 鋭い平坦な面の代わりに、柔らかく成形されたエッジを追加します。 |
| [getContourColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getContourWidth), と [setContourWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#setContourWidth) | 3D オブジェクトの輪郭線。 | レンダリング結果でオブジェクトの境界を強調します。 |

## **3D シェイプの作成**

シェイプが説得力のある 3D に見えるためには、通常、4 種類の設定が必要です：

- カメラ設定：デフォルトの正面ビューでは押し出しが見えなくなる可能性があるため。
- ライト設定：照明により面や側面が視認しやすくなるため。
- 素材設定：表面が光のレンダリングに影響するため。
- 押し出しまたは深さ設定：平面のシェイプに厚みが必要なため。

以下の例では、長方形を作成し、正面にテキストを追加し、3D 書式設定を適用し、プレゼンテーションを PPTX として保存し、スライドを PNG 画像としてレンダリングします。

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

レンダリングされたスライド画像は、長方形が厚みのある 3D ブロックとして表示されます：

![正面に白色の 3D テキストがある、青い 3D 長方形のレンダリング画像](img_01_01.png)

## **カメラでシェイプを回転する**

PowerPoint では、3-D 回転は「3-D 回転」ペインから設定します。X、Y、Z の回転値は、カメラ API を通じて設定する回転に対応しています。

![X、Y、Z の回転値がハイライトされた PowerPoint の 3-D 回転ペイン](img_02_01.png)

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

ビューアがオブジェクトを見る視点を変更したい場合にカメラを使用します。これはスライド上の 2D シェイプジオメトリを変更するものではなく、PowerPoint および Aspose.Slides がレンダリング時に使用する 3D 視点を変更します。

## **押し出しと深さの追加**

押し出しは、シェイプの正面の背後に拡張することで厚みを持たせます。PowerPoint では、深さコントロールがこの可視的な厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint の深さコントロールが押し出し色と押し出し高さプロパティに対応している様子](img_02_02.png)

厚みのために押し出し高さを、側面の色のために押し出し色を設定します：

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

PowerPoint の深さ値を直接操作したり、深さをベベル、素材、テキスト効果と組み合わせたりする必要がある場合に深さ設定を使用します。多くのシェイプシナリオでは、押し出し高さの方が可視的な押し出しを直接表すため、より明確な設定となります。

## **3D 効果とともにグラデーションまたは画像塗りつぶしを使用する**

3D 書式設定はシェイプの塗りつぶしとは独立しています。正面に単色、グラデーション、パターン、または画像塗りつぶしを適用しつつ、同じカメラ、ライト、素材、押し出し設定を使用できます。

この例ではシェイプにグラデーション塗りつぶしを適用し、側面には濃い押し出し色を設定します：

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

レンダリング結果は正面のグラデーションを保持し、押し出しを別個に描画します：

![青からオレンジへのグラデーション塗りつぶしとオレンジの押し出しを持つ 3D 長方形のレンダリング画像](img_02_03.png)

画像を使用する場合は、画像をプレゼンテーションに追加し、シェイプの塗りつぶしに割り当てます：

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

画像は正面にレンダリングされ、押し出しは 3D 側面として描画されます：

![正面に写真塗りつぶし、側面にオレンジの押し出しを持つ 3D 長方形のレンダリング画像](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響し、テキストの 3D 書式設定はテキストフレームに影響します。文字自体に押し出し、素材、照明、カメラ設定が必要な WordArt のような効果に有用です。

以下の例では、パターン塗りつぶしのテキストを作成し、WordArt 変形を適用し、[TextFrameFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/) に 3D 設定を構成します：

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

テキストは曲線状で押し出された 3D 文字としてレンダリングされます：

![アーチ状の WordArt 変形、オレンジのパターン塗りつぶし、暗い押し出しを持つ 3D テキストのレンダリング画像](img_02_05.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスタライズされ、2D 結果として出力に描画されます。これはスライドを PNG にレンダリングする、PDF にエクスポートする、HTML にエクスポートする、またはビデオ変換用のフレームを生成する場合に適用されます。

以下の点に留意してください：

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。
- 最終的な外観は、カメラ、ライトリグ、素材、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承されたフォーマットやテーマベースのフォーマット値を確認する必要がある場合は、effective formatting API を使用してください。
- 一部の出力形式では、編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、視覚的な結果がレンダリングされ、編集可能な 3D 設定として保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプとテキストに対する PowerPoint の 3D 効果を作成およびレンダリングします。エクスポートされた画像、PDF、HTML ページを、ビューアが回転させられるインタラクティブな 3D シーンにすることはありません。PPTX では、対応フォーマットであれば 3D 書式設定は PowerPoint で編集可能なまま残ります。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルは、プレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は、通常の PowerPoint シェイプやテキストに適用される書式設定で、回転、押し出し、ベベル、照明、素材などがあります。本記事は 3D 効果について解説しています。

**見える 3D シェイプに必要な設定は何ですか？**

最低限、カメラの回転と押し出しまたは深さのいずれかを設定します。実際には、レンダリングされた面に明確なハイライトと影を持たせるために、ライトリグと素材も設定することが一般的です。

**シェイプとテキストの両方に 3D 効果を適用できますか？**

はい。シェイプ本体には [Shape.getThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getThreeDFormat) を、テキストには [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#getThreeDFormat) を使用します。

**画像、PDF、HTML、ビデオフレームへエクスポートする際に 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF、HTML、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。最終的なカメラ、ライトリグ、ベベル、関連する 3D 値を取得するには、[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getEffective) を使用します。