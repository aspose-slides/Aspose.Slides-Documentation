---
title: Python via Java でプレゼンテーションの図形効果を適用する
linktitle: 図形効果
type: docs
weight: 30
url: /ja/python-java/shape-effect/
keywords:
- 図形効果
- 影効果
- 反射効果
- グロウ効果
- ソフトエッジ効果
- 効果フォーマット
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して高度な図形効果で PPT と PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **はじめに**

PowerPoint の効果は図形を目立たせるために使用できますが、[塗りつぶし](/slides/ja/python-java/shape-formatting/#gradient-fill) やアウトラインとは異なります。PowerPoint の効果を使用すると、図形に説得力のある反射を作成したり、図形のグロウを広げたりすることができます。

![Shape effect](shape-effect.png)

PowerPoint は図形に適用できる 6 つの効果を提供しています。図形に 1 つまたは複数の効果を適用できます。

効果の組み合わせの中には、他よりも見栄えが良いものがあります。このため、PowerPoint は **Preset** の下にオプションを提供しています。Preset のオプションは、見栄えが良いとされる 2 つ以上の効果の組み合わせです。このように、プリセットを選択するだけで、さまざまな効果を試したり組み合わせて最適な組み合わせを見つける時間を無駄にする必要がなくなります。

Aspose.Slides は、PowerPoint プレゼンテーションの図形に同じ効果を適用できるように、[EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供しています。

## **影効果を適用する**

Aspose.Slides for Python via Java は図形の外部および内部の影をサポートしています。影の色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外部影を適用する**

外部影を使用して、カードやパネルをスライドの背景に対して目立たせます。影は図形のエッジの外側まで広がり、図形がスライド上に持ち上げられているように見えます。影の色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせます。

この Python コードは、矩形に [外部影効果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) を適用する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Shadow effect](shadow_effect.png)

#### **図形が回転するときの影の方向の制御**

デフォルトでは、外部影は図形とともに回転します。異なる回転角度の図形が同じ方向から照らされているようにするには、`False` を指定して [setRotateShadowWithShape](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setRotateShadowWithShape) を呼び出し、[setDirection](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setDirection) を使用して影の方向を統一します。

この例では、右に 42 ポイントオフセットした (0°) グレーの影を持つ青い矢印を 2 本作成します。その後、スライドを複製し、両方の矢印を時計回りに 90° 回転させます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    before = presentation.getSlides().get_Item(0)
    
    left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60)
    left.getFillFormat().setFillType(FillType.Solid)
    left.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    left.getEffectFormat().enableOuterShadowEffect()
    shadow = left.getEffectFormat().getOuterShadowEffect()
    shadow.getShadowColor().setColor(Color.GRAY)
    shadow.setDirection(0)
    shadow.setDistance(42)
    shadow.setBlurRadius(0)
    shadow.setRotateShadowWithShape(True)

    right = before.getShapes().addClone(left)
    right.setX(395)
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(False)

    after = presentation.getSlides().addClone(before)
    for arrow in after.getShapes():
        arrow.setRotation(90)

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

2 枚目のスライドでは、左側の矢印の影は下向きに落ち、右側の矢印の影は依然として右向きです。設定された方向は両方の影で 0° のままです。

![PowerPoint rendering before and after a 90° rotation. Both shadows start on the right. After rotation, the shadow moves below the left arrow and stays to the right of the right arrow.](arrow-shadow-rotation.png)

### **内部影を適用する**

テンプレートのビジュアルスタイルを再現する際は、内部影を使用してカードやパネルにくぼんだ外観を付けます。外部影は図形の外側に広がり、浮き上がって見えるのに対し、内部影はエッジの内部を陰影付けします。

まず [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) を呼び出し、次に [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) が返す影を設定します。ぼかし半径の値が大きいほど、エッジが柔らかくなります。

この Python の例は、淡い青色のカードに濃い灰色の内部影を付け、PPTX ファイルとして保存します。影の方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

内部影を削除するには、図形の EffectFormat で [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) を呼び出します。

### **プリセット影を適用、変更、削除する**

まず [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect) を呼び出し、次に [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) を使用して [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/) を選択します。スタイルを切り替えるには、同じ図形のプリセットを変更します。塗りつぶしやアウトラインを保持したまま影を削除するには、[disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) を呼び出します。

この例では、各段階で矩形を複製し、1 つのスライドで 4 つの状態を横に比較できるようにしています。両方の影は 10 ポイントオフセットしています。方向が 225° の場合、最初の影は矩形の上部左側に配置されます。方向が 45° の場合、2 番目の影は下部右側に配置されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| 元の状態 | 最初のプリセット | 2 番目のプリセット | 削除後 |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **反射効果を適用する**

Aspose.Slides for Python via Java で反射効果を適用するには、図形に鏡のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。この効果により、図形がより洗練された外観になり、プレゼンテーションの美観が向上します。シンプルなコードで簡単に実装でき、複数の要素に素早く適用して一貫したデザインを実現できます。

この Python コードは、図形に [反射効果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) を適用する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Reflection effect](reflection_effect.png)

## **グロウ効果を適用する**

Aspose.Slides for Python via Java で図形にグロウ効果を適用するには、図形の周囲に柔らかく光るオーラを追加し、色やサイズなどのプロパティを調整します。この効果は図形を際立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の見栄えが向上します。

この Python コードは、図形に [グロウ効果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) を適用する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Glow effect](glow_effect.png)

## **ソフトエッジ効果を適用する**

Aspose.Slides for Python via Java でソフトエッジ効果を適用すると、図形のエッジ周辺に滑らかでぼかされた遷移を作成できます。この効果は、より繊細で洗練された外観を付加し、優しい外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな図形に目的の効果を実現できます。

この Python コードは、図形に [ソフトエッジ効果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) を適用する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Soft edges effect](soft_edges_effect.png)

## **ぼかし効果を適用する**

形状のぼかしを使用すると、形状を編集可能なまま塗りつぶしとアウトラインを柔らかくできます。形状の EffectFormat で [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) を呼び出します。半径はポイント (1/72 インチ) で測定され、負の値は使用できず、値が大きいほど強いぼかしになります。半径が 0 の場合、外観は変わりません。

[getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) 設定は効果の可視境界を制御します。`False` の場合、ぼかしは元の描画境界（アウトラインを含む）にクリップされます。`True` の場合、ぼかしはその境界を超えて広がります。どちらの設定も形状の位置やサイズは変更しません。

以下の比較では、同じ塗り、アウトライン、形状サイズを使用しています。上段は `grow = False`、下段は `grow = True` を使用しています。

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

この Python の例は、オレンジ色の矩形に濃い青のアウトラインを付け、5 ポイントのぼかしを適用し、次に [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) を再度呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存し、その後 [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) を呼び出してぼかしなしの形状を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

形状のぼかしは塗りとアウトラインの両方に影響します。ソフトエッジ効果は形状のエッジをフェードさせ、影のぼかしは影のみを柔らかくします。画像変換効果は画像コンテンツに対して操作しますが、この例は形状を画像に変換せずに、直接形状の EffectFormat にぼかしを適用しています。

## **よくある質問**

**同じ図形に複数の効果を適用できますか？**

はい、影、反射、グロウなどの異なる効果を組み合わせて、1 つの図形に適用し、よりダイナミックな外観を作成できます。

**どのような図形に効果を適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形に効果を適用できます。

**グループ化された図形に効果を適用できますか？**

はい、グループ化された図形にも効果を適用できます。効果はグループ全体に適用されます。