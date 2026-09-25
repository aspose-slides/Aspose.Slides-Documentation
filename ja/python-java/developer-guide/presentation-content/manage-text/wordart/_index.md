---
title: Python via Java で WordArt 効果を作成および適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/python-java/wordart/
keywords:
- WordArt
- WordArt の作成
- WordArt テンプレート
- WordArt 効果
- 影効果
- 反射効果
- グロー効果
- WordArt 変形
- 3D 効果
- 外側影効果
- 内側影効果
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java で WordArt 効果を作成・カスタマイズします。このステップバイステップガイドは、開発者が Python via Java でプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---
## **概要**

WordArt の効果により、塗り、輪郭、影、反射、グロー、変形、3D 書式設定でテキストを装飾できます。本記事では、Microsoft Office をインストールせずに、Aspose.Slides for Python via Java を使用して PowerPoint プレゼンテーションでこれらの効果を作成およびカスタマイズする方法を説明します。

## **シンプルな WordArt テンプレートを作成し、テキストに適用する**

以下の例は、テキスト、フォント、パターン 塗り、輪郭を設定してシンプルな WordArt スタイルを構築します。

各例は新しいプレゼンテーションを作成し、最初のスライドに長方形を追加します。入力ファイルは必要ありません。最初の例ではテキストを "Aspose.Slides" に設定します。シェイプの位置とサイズはポイントで測定されます:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```

フォーマットをより目立たせるために、フォントを 36 ポイントの Arial Black に設定します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)
finally:
    presentation.dispose()
```

暗いオレンジの前景と白い背景の [SmallGrid](https://reference.aspose.com/slides/ja/python-java/aspose.slides/patternstyle/#SmallGrid) パターンを適用し、幅 1 ポイントの黒いテキスト輪郭を追加します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    dark_orange = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(dark_orange)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid)

    portion.getPortionFormat().getLineFormat().setWidth(1)
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

結果のテキスト:

![シンプルな WordArt テンプレート](WordArt_template.png)

## **その他の WordArt 効果を適用する**

以下の例は、テキストに影、反射、グロー、変形、3D 効果を適用する方法を示します。

### **外側の影効果を適用する**

外側の影はテキストの背後に影を置くことで奥行きを加えます。色、方向、距離、ぼかし半径、スケール、斜め方向をカスタマイズできます。

この例では [enableOuterShadowEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effectformat/#enableOuterShadowEffect) を呼び出し、ぼかし半径 4 ポイント、方向 230 度、距離 30 ポイントの黒い影を設定します。スケール値 100 は影のサイズを維持し、水平斜め 20 度で傾けます。アルファ変換で不透明度を 32% に設定します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect()
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

結果のテキスト:

![外側の影効果](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- 外側の影とプリセットの影を同時に使用すると、外側の影のみが適用されます。
- 外側の影と内側の影を同時に使用した場合、結果の効果は PowerPoint のバージョンに依存します。例として、PowerPoint 2013 では効果が2倍になり、PowerPoint 2007 では外側の影のみが適用されます。
{{% /alert %}}

### **反射効果を適用する**

反射はテキストの鏡像コピーを作成します。位置、スケール、ぼかし、透明度を調整して外観を制御します。

この例では [enableReflectionEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effectformat/#enableReflectionEffect) を呼び出し、スケール -100% で反射を垂直に反転させます。ぼかし半径 0.5 ポイント、距離 4.72 ポイントを使用します。透明度は、反射上の位置 0% から 60% の間で 60% から 0.9% に減少します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect()
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

結果のテキスト:

![反射効果](reflection_effect.png)

### **グロー効果を適用する**

グローはテキストの周囲に柔らかなカラー輪郭を追加します。色、透明度、半径を調整して効果を制御します。

この例では [enableGlowEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effectformat/#enableGlowEffect) を呼び出し、透明度 54%、半径 7 ポイントの赤いグローを適用します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableGlowEffect()
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7)
finally:
    presentation.dispose()
```

結果のテキスト:

![グロー効果](glow_effect.png)

### **WordArt 変形を適用する**

WordArt の変形はテキストブロックを曲げたり、伸ばしたり、歪めたりします。

[setTransform](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setTransform) を [ArchUpPour](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textshapetype/#ArchUpPour) に設定して、テキストフレーム全体を上向きに曲げます:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")
    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

結果のテキスト:

![WordArt 変形](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java は、事前定義された [transformation types](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textshapetype/) のセットを提供します。
{{% /alert %}}

### **シェイプとテキストに 3D 効果を適用する**

シェイプまたはそのテキストに 3D 効果を適用できます。ベベル、押し出し、照明、カメラ設定が結果の外観を制御します。

以下の例では [ThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/) を使用して、長方形に円形ベベル、オレンジ色の押し出し、濃い赤の輪郭を追加します。ベベルの寸法、押し出しの高さ、輪郭の幅、深さはポイントで測定されます。プラスチック素材、Z 軸周りに 40 度回転したバランス照明、遠近カメラが外観を定義します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    auto_shape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelBottom().setHeight(10.5)
    auto_shape.getThreeDFormat().getBevelBottom().setWidth(10.5)

    auto_shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelTop().setHeight(12.5)
    auto_shape.getThreeDFormat().getBevelTop().setWidth(11)

    orange = Color(255, 165, 0)
    auto_shape.getThreeDFormat().getExtrusionColor().setColor(orange)
    auto_shape.getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    auto_shape.getThreeDFormat().getContourColor().setColor(dark_red)
    auto_shape.getThreeDFormat().setContourWidth(1.5)

    auto_shape.getThreeDFormat().setDepth(3)

    auto_shape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    auto_shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    auto_shape.getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

結果のシェイプ:

![シェイプの 3D 効果](shape_3D_effect.png)

この例では [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#getThreeDFormat) を通じてテキストにも同様の 3D 書式設定を適用します。小さなベベルが文字のエッジを形作り、押し出しと照明がテキストに奥行きを与えます:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5)

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4)

    orange = Color(255, 165, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange)
    text_frame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(dark_red)
    text_frame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5)

    text_frame.getTextFrameFormat().getThreeDFormat().setDepth(3)

    text_frame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    text_frame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

結果のテキスト:

![テキストの 3D 効果](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
テキストまたはシェイプへの 3D 効果の適用と、これらの効果間の相互作用は、特定のルールで管理されます。テキストとそれを含むシェイプの両方が関与するシーンを考えてみてください。3D 効果はオブジェクトの 3D 表現と配置されたシーンを含みます。

- シェイプとテキストの両方にシーンが設定されている場合、シェイプのシーンが優先され、テキストのシーンは無視されます。
- シェイプに独自のシーンがなく 3D 表現だけがある場合、テキストのシーンが使用されます。
- シェイプに 3D 効果が全くない場合、フラットとして扱われ、3D 効果はテキストのみに適用されます。

これらの動作は、[ThreeDFormat.getLightRig](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getLightRig) および [ThreeDFormat.getCamera](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getCamera) メソッドに関連しています。
{{% /alert %}}

テキストを平坦で読みやすく保ちつつシェイプの 3D 書式設定を保持するには、[Keep Text Flat on a 3D Shape](/slides/ja/python-java/3d-presentation/) を参照して、両方の設定の比較と完全な Python サンプルをご覧ください。

## **よくある質問**

**異なるフォントやスクリプト（例: アラビア語、中国語）で WordArt 効果を使用できますか？**

はい、Aspose.Slides for Python via Java は Unicode をサポートしており、すべての主要なフォントとスクリプトで動作します。影、塗り、輪郭などの WordArt 効果は言語に関係なく適用できますが、フォントの利用可能性や描画はシステムフォントに依存する場合があります。

**スライドマスタ要素に WordArt 効果を適用できますか？**

はい、マスタースライド上のシェイプ（タイトルプレースホルダー、フッター、背景テキストなど）に WordArt 効果を適用できます。マスターのレイアウトに加えた変更は、関連するすべてのスライドに反映されます。

**WordArt 効果はプレゼンテーションのファイルサイズに影響しますか？**

少しだけ。影、グロー、グラデーション塗りなどの WordArt 効果は、追加の書式メタデータによりファイルサイズを僅かに増加させる可能性がありますが、差は通常無視できる程度です。

**プレゼンテーションを保存せずに WordArt 効果の結果をプレビューできますか？**

はい、[Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) を使用して WordArt を含むスライドを画像（例: PNG、JPEG）にレンダリングしたり、[Shape.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getImage) で個々のシェイプをレンダリングしたりできます。これにより、プレゼンテーション全体を保存またはエクスポートする前に、メモリ上または画面上で結果をプレビューできます。