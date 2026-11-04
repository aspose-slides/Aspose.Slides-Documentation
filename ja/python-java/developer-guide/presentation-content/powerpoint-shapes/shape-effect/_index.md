---
title: Python via Java を使用したプレゼンテーションでのシェイプ効果の適用
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
- 効果フォーマット
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して高度なシェイプ効果で PPT および PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **概要**

PowerPoint の効果は形状を目立たせるために使用できますが、[塗りつぶし](/slides/ja/python-java/shape-formatting/#gradient-fill) やアウトラインとは異なります。PowerPoint の効果を使用すると、形状に説得力のある反射を作成したり、形状のグローを広げたりすることができます。

![Shape effect](shape-effect.png)

PowerPoint は、形状に適用できる 6 つの効果を提供しています。1 つまたは複数の効果を形状に適用できます。

効果の組み合わせの中には、他より見栄えが良いものがあります。そのため、PowerPoint は **Preset** の下にオプションを提供しています。Preset オプションは、見栄えが良いとされる 2 つ以上の効果の組み合わせです。これにより、プリセットを選択すれば、時間をかけてさまざまな効果をテストしたり組み合わせたりする必要がなくなります。

Aspose.Slides は、PowerPoint プレゼンテーションの形状に同じ効果を適用できるように、[EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供しています。

## **影効果の適用**

Aspose.Slides for Python via Java は、形状に対する外側と内側の影をサポートしています。色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側の影を適用**

外側の影を使用して、カードやパネルをスライドの背景に対して目立たせます。影は形状のエッジの外側に広がり、形状がスライド上に浮き上がっているように見えます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイリングに合わせます。

この Python コードは、長方形に[外側の影エフェクト](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) を適用する方法を示しています：

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

### **内側の影を適用**

テンプレートのビジュアルスタイリングを再現する場合、内側の影を使用してカードやパネルにくぼんだ外観を付けます。外側の影は形状の外側に広がり、浮き上がって見えるのに対し、内側の影はエッジの内部をシェーディングします。

[enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) を呼び出し、続いて [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) が返す影を構成します。ぼかし半径の値が大きいほど、エッジは柔らかくなります。

この Python の例は、淡い青色のカードに濃い灰色の内側の影を付けて PPTX ファイルとして保存します。影の方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです：

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

![内側の影がある淡い青色の長方形](inner_shadow_effect.png)

内側の影を削除するには、形状の effect format に対して [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) を呼び出します。

## **反射効果の適用**

Aspose.Slides for Python via Java で反射効果を適用するには、形状に鏡面のような反射を追加し、距離、透過率、サイズなどのパラメーターを調整できます。この効果は、形状により洗練された外観を与えてプレゼンテーションの美観を高めます。シンプルなコードで簡単に実装でき、複数の要素に素早く適用して一貫したデザインを実現できます。

この Python コードは、形状に[反射効果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) を適用する方法を示しています：

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

Aspose.Slides for Python via Java で形状にグロー効果を適用するには、形状の周囲に柔らかい光のオーラを追加し、色やサイズなどのプロパティを調整できます。この効果は形状を際立たせ、プレゼンテーションに目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の見た目を向上させます。

この Python コードは、形状に[グロー効果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) を適用する方法を示しています：

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

Aspose.Slides for Python via Java でソフトエッジ効果を適用すると、形状のエッジ周辺に滑らかでぼやけたトランジションを作り出せます。この効果は、より微妙で上品な外観を加え、優しい外観が必要なデザインに最適です。半径などのパラメーターを簡単に調整して、プレゼンテーション内のさまざまな形状に望む効果を実現できます。

この Python コードは、形状に[ソフトエッジ効果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) を適用する方法を示しています：

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

形状のぼかしを使用すると、形状の塗りつぶしとアウトラインをソフトにしながら、形状自体は編集可能なままにできます。形状の effect format に対して [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) を呼び出します。半径はポイント単位 (1/72 インチ) で測定され、0 以上の値を使用し、値が大きいほどぼかしが強くなります。半径が 0 の場合は外観は変更されません。

[getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) 設定は効果の可視境界を制御します。`False` の場合、ぼかしは元の描画境界（アウトラインを含む）にクリップされます。`True` の場合、ぼかしはその境界を超えて広がることができます。どちらの設定も形状の位置やサイズは変更しません。

以下の比較は、全体で同じ塗りつぶし、アウトライン、形状サイズを使用しています。上段は `grow = False`、下段は `grow = True` です。

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

この Python の例は、オレンジ色の長方形に濃い青色のアウトラインを付け、5 ポイントのぼかしを適用し、続いて [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) を再度呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存した後、[disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) を呼び出し、ぼかしのない形状を保存します。

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

形状のぼかしは塗りつぶしとアウトラインの両方に影響します。ソフトエッジ効果は形状のエッジをフェードさせますが、影のぼかしは影だけをソフトにします。画像変換効果は画像コンテンツに対して動作しますが、この例では形状を画像に変換せず、直接 shape の effect format にぼかしを適用しています。

## **FAQ**

**同じ形状に複数の効果を適用できますか？**

はい、影、反射、グローなど異なる効果を組み合わせて、単一の形状によりダイナミックな外観を作り出すことができます。

**どのような形状に効果を適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな形状に効果を適用できます。

**グループ化された形状に効果を適用できますか？**

はい、グループ化された形状全体に効果を適用できます。効果はグループ全体に適用されます。