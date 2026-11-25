---
title: Python (via Java) を使用してプレゼンテーションにシェイプ効果を適用する
linktitle: シェイプ効果
type: docs
weight: 30
url: /ja/python-java/shape-effect/
keywords:
- シェイプ効果
- 影効果
- 反射効果
- グロー効果
- ソフトエッジ効果
- エフェクトフォーマット
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して高度なシェイプ効果で PPT および PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **はじめに**

PowerPoint の効果はシェイプを際立たせるために使用できますが、[塗りつぶし](/slides/ja/python-java/shape-formatting/#gradient-fill)や輪郭とは異なります。PowerPoint の効果を使用すると、シェイプにリアルな反射を作成したり、シェイプのグローを広げたりすることができます。

![Shape effect](shape-effect.png)

PowerPoint では、シェイプに適用できる 6 つの効果が提供されています。シェイプに 1 つまたは複数の効果を適用できます。

効果の組み合わせによっては、他よりも見栄えが良くなります。そのため、PowerPoint は **Preset** の下にオプションを提供しています。Preset オプションは、見栄えが良いと知られている 2 つ以上の効果の組み合わせです。このように、プリセットを選択すれば、最適な組み合わせを探すために効果をテストしたり組み合わせたりする時間を無駄にする必要がありません。

Aspose.Slides は、PowerPoint プレゼンテーションのシェイプに同じ効果を適用できるように、[EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供しています。

## **影効果の適用**

Aspose.Slides for Python via Java は、シェイプの外側および内側の影をサポートしています。影の色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側影の適用**

外側影を使用すると、カードやパネルがスライドの背景に対して際立ちます。影はシェイプのエッジの外側に広がり、シェイプがスライド上に持ち上がっているように見えます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせてください。

この Python コードは、長方形に [外側影効果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) を適用する方法を示しています。
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

![影効果](shadow_effect.png)

### **内側影の適用**

テンプレートのビジュアルスタイルを再現する際は、内側影を使用してカードやパネルにくぼんだ外観を与えます。外側影はシェイプの外側に広がり、持ち上がって見えるのに対し、内側影はエッジの内側を影付けします。

まず [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) を呼び出し、次に [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) が返す影を構成します。ぼかし半径の値が大きいほど、エッジが柔らかくなります。

この Python の例は、薄い青色のカードに濃い灰色の内側影を付け、PPTX ファイルとして保存します。影の方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです。
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

![内側影付きの淡青色長方形](inner_shadow_effect.png)

内側影を削除するには、シェイプの EffectFormat に対して [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) を呼び出します。

### **プリセット影の適用、変更、削除**

まず [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect) を呼び出し、次に [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) を使用して [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/) を選択します。同じシェイプでスタイルを切り替えるには、プリセットを変更します。塗りつぶしと輪郭を保持したまま影を削除するには、[disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) を呼び出します。

この例は各段階で長方形をクローンし、1 枚のスライド上で 4 つの状態を並べて比較できるようにしています。両方の影は 10 ポイントオフセットされています。方向が 225° の場合、最初の影は長方形の左上に配置されます。方向が 45° の場合、2 番目の影は右下に配置されます。
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

| 原本 | 最初のプリセット | 2 番目のプリセット | 削除後 |
| :---: | :---: | :---: | :---: |
| ![影なし](preset_shadow_original.png) | ![左上ドロップ影](preset_shadow_top_left.png) | ![右下ドロップ影](preset_shadow_bottom_right.png) | ![削除後の影なし](preset_shadow_removed.png) |

## **反射効果の適用**

Aspose.Slides for Python via Java で反射効果を適用するには、シェイプに鏡のような反射を追加し、距離、透明度、サイズなどのパラメータを調整できます。この効果はシェイプをより洗練された外観にし、プレゼンテーションの美観を高めます。シンプルなコードで簡単に実装でき、複数の要素に迅速に適用して統一感のあるデザインが実現できます。

この Python コードは、シェイプに [反射効果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) を適用する方法を示しています。
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

![反射効果](reflection_effect.png)

## **グロー効果の適用**

Aspose.Slides for Python via Java でシェイプにグロー効果を適用するには、シェイプの周囲に柔らかく光るオーラを追加し、色やサイズなどのプロパティを調整できます。この効果はシェイプを際立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の見栄えが向上します。

この Python コードは、シェイプに [グロー効果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) を適用する方法を示しています。
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

![グロー効果](glow_effect.png)

## **ソフトエッジ効果の適用**

Aspose.Slides for Python via Java でソフトエッジ効果を適用するには、シェイプのエッジ周辺に滑らかでぼやけたトランジションを作成できます。この効果はより繊細で洗練された外観を加え、柔らかく穏やかな外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまなシェイプに目的の効果を実現できます。

この Python コードは、シェイプに [ソフトエッジ効果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) を適用する方法を示しています。
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

![ソフトエッジ効果](soft_edges_effect.png)

## **ぼかし効果の適用**

シェイプのぼかしを使用して、シェイプの塗りつぶしと輪郭をソフトにしながら、シェイプを編集可能な状態に保ちます。シェイプの EffectFormat で [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) を呼び出します。半径はポイント (1/72 インチ) で測定され、負でない値を使用し、値が大きいほど強いぼかしになります。半径が 0 の場合、外観は変わりません。

[getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) 設定は効果の可視範囲を制御します。`False` の場合、ぼかしは元の描画範囲（輪郭を含む）にクリップされます。`True` の場合、ぼかしはその範囲を超えて拡張できます。いずれの設定もシェイプの位置やサイズは変更しません。

以下の比較は、全体で同じ塗りつぶし、輪郭、シェイプサイズを使用しています。上段は `grow = False`、下段は `grow = True` を使用しています。

![ぼかし半径 5 と 15 ポイント、grow 無効/有効のオリジナル長方形比較](shape_blur_comparison.png)

この Python の例は、オレンジ色の長方形に濃い青色の輪郭を付け、5 ポイントのぼかしを適用し、次に [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) を再度呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存し、次に [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) を呼び出してぼかしなしのシェイプを保存します。
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

シェイプのぼかしは塗りつぶしと輪郭の両方に影響します。ソフトエッジ効果はシェイプのエッジをフェードさせ、影のぼかしは影だけをソフトにします。画像変換効果は画像コンテンツに対して動作しますが、この例ではシェイプを画像に変換せず、シェイプの EffectFormat に直接ぼかしを適用しています。

## **よくある質問**

**同じシェイプに複数の効果を適用できますか？**

はい、影、反射、グローなど、さまざまな効果を組み合わせて単一のシェイプに適用し、よりダイナミックな外観を作成できます。

**どのシェイプに効果を適用できますか？**

自動図形、チャート、表、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまなシェイプに効果を適用できます。

**グループ化されたシェイプに効果を適用できますか？**

はい、グループ化されたシェイプにも効果を適用できます。効果はグループ全体に適用されます。