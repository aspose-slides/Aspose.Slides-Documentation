---
title: Python via Java を使用してプレゼンテーションでシェイプ エフェクトを適用する
linktitle: シェイプ エフェクト
type: docs
weight: 30
url: /ja/python-java/shape-effect/
keywords:
- シェイプ エフェクト
- 影 エフェクト
- リフレクション エフェクト
- グロー エフェクト
- ソフト エッジ エフェクト
- エフェクト フォーマット
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して高度なシェイプ エフェクトで PPT および PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **イントロダクション**

PowerPoint のエフェクトはシェイプを目立たせるために使用できますが、[fills](/slides/ja/python-java/shape-formatting/#gradient-fill) やアウトラインとは異なります。PowerPoint のエフェクトを使用すると、シェイプにリアルな反射を作成したり、シェイプのグローを広げたりできます。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint にはシェイプに適用できる 6 つのエフェクトが用意されています。1 つまたは複数のエフェクトをシェイプに適用できます。  
* エフェクトの組み合わせの中には、他よりも見栄えが良いものがあります。そのため、PowerPoint では **Preset** の下にオプションが用意されています。Preset オプションは、見栄えが良いと知られている 2 つ以上のエフェクトの組み合わせです。プリセットを選択すれば、さまざまなエフェクトをテストしたり組み合わせたりして最適な組み合わせを探す手間が省けます。

Aspose.Slides は、PowerPoint プレゼンテーションのシェイプに同じエフェクトを適用できるように、[EffectFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供しています。

## **シャドウ エフェクトの適用**

この Python コードは、外側シャドウ エフェクト ([EffectFormat.getOuterShadowEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effectformat/#getOuterShadowEffect)) を矩形に適用する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY)
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **リフレクション エフェクトの適用**

この Python コードは、シェイプにリフレクション エフェクトを適用する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(55)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4)

    presentation.save("reflection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **グロー エフェクトの適用**

この Python コードは、シェイプにグロー エフェクトを適用する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ソフト エッジ エフェクトの適用**

この Python コードは、シェイプにソフト エッジ エフェクトを適用する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15)

    presentation.save("softEdges.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**同じシェイプに複数のエフェクトを適用できますか？**

はい、影、リフレクション、グローなどの異なるエフェクトを単一のシェイプに組み合わせて、より動的な外観を作成できます。

**どのようなシェイプにエフェクトを適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまなシェイプにエフェクトを適用できます。

**グループ化されたシェイプにエフェクトを適用できますか？**

はい、グループ化されたシェイプ全体にエフェクトが適用されます。