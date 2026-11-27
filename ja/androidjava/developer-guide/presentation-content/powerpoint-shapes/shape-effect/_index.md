---
title: Android のプレゼンテーションでシェイプ効果を適用する
linktitle: シェイプ効果
type: docs
weight: 30
url: /ja/androidjava/shape-effect/
keywords:
- シェイプ効果
- 影効果
- 反射効果
- 光彩効果
- ソフトエッジ効果
- エフェクト フォーマット
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PPT と PPTX ファイルに高度なシェイプ効果を適用し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **イントロダクション**

PowerPoint のエフェクトは図形を目立たせるために使用できますが、[塗りつぶし](/slides/ja/androidjava/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPoint のエフェクトを使用すると、図形にリアルな反射を付けたり、図形の光彩を広げたりすることができます。

![形状エフェクト](shape-effect.png)

PowerPoint には図形に適用できる 6 種類のエフェクトが用意されています。1 つまたは複数のエフェクトを図形に適用できます。

エフェクトの組み合わせによって見栄えが異なります。そのため、PowerPoint では **プリセット** オプションが用意されています。プリセットは、見栄えが良いと判明している 2 つ以上のエフェクトの組み合わせです。プリセットを選択すれば、さまざまなエフェクトを試したり組み合わせたりして最適な組み合わせを探す手間が省けます。

Aspose.Slides は、[EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) クラスのプロパティとメソッドを提供しており、PowerPoint プレゼンテーションの図形に同じエフェクトを適用できます。

## **影エフェクトの適用**

Aspose.Slides for Android via Java は、図形に対して外側影と内側影の両方をサポートします。色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側影の適用**

外側影を使用すると、カードやパネルがスライドの背景から際立ちます。影は図形の端の外側に広がり、図形がスライド上に浮き上がっているように見せます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせてください。

この Java コードは、矩形に[外側の影エフェクト](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) を適用する方法を示しています。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![影エフェクト](shadow_effect.png)

#### **図形の回転時に影の方向を制御する**

既定では、外側影は図形とともに回転します。異なる回転角度の図形でも同じ方向から光が当たっているように見せたい場合は、`false` を指定して [setRotateShadowWithShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) を呼び出し、[setDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setDirection-float-) で同一方向を設定します。

この例では、左に 42 ポイントオフセットした灰色の影を持つ青い矢印を 2 本作成します (0°)。次にスライドを複製し、両方の矢印を時計回りに 90° 回転させます。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(128, 128, 128));
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    IShape right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    ISlide after = presentation.getSlides().addClone(before);
    for (IShape arrow : after.getShapes()) {
        arrow.setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

2 番目のスライドでは、左側の矢印の影は下向きに、右側の矢印の影は右向きのままです。設定された方向は両方の影で 0° のままです。

![PowerPoint の 90° 回転前後のレンダリング。両方の影は右側から開始し、回転後は左矢印の下に、右矢印の右側に残ります。](arrow-shadow-rotation.png)

### **内側影の適用**

テンプレートのビジュアルスタイルを再現する場合は、内側影を使用してカードやパネルに凹んだ外観を付けます。外側影は図形の外側に広がり浮き上がって見えるのに対し、内側影は図形のエッジ内部をシェーディングします。

[enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) を呼び出し、[getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) が返す影を設定します。ぼかし半径の値が大きいほど、エッジは柔らかくなります。

この Java の例は、淡い青色のカードに濃い灰色の内側影を付け、PPTX ファイルとして保存します。影の方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![内側影付きの淡い青色矩形](inner_shadow_effect.png)

内側影を削除するには、図形のエフェクト フォーマットで [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) を呼び出します。

### **プリセット影の適用・変更・削除**

[enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) を呼び出し、[setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-) で [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/) を選択します。同じ図形上でスタイルを切り替えるには、プリセットを変更します。影を削除して塗りつぶしとアウトラインは保持したい場合は、[disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) を呼び出します。

この例は、1 枚のスライド上で 4 段階を横並びで示しています。両方の影は 10 ポイントオフセットされています。方向 225° は最初の影を矩形の左上に配置し、45° は 2 番目の影を右下に配置します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| オリジナル | 最初のプリセット | 2番目のプリセット | 削除後 |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **反射エフェクトの適用**

Aspose.Slides for Android via Java で反射エフェクトを適用するには、図形に鏡面のような反射を加え、距離、透明度、サイズなどのパラメーターを調整します。このエフェクトは、図形に洗練された外観を与え、プレゼンテーションの美しさを向上させます。シンプルなコードで簡単に実装でき、複数の要素に一貫したデザインをすばやく適用できます。

この Java コードは、図形に[反射エフェクト](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) を適用する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![反射エフェクト](reflection_effect.png)

## **光彩エフェクトの適用**

Aspose.Slides for Android via Java で光彩エフェクトを適用するには、図形の周囲に柔らかな光のオーラを加え、色やサイズなどのプロパティを調整します。このエフェクトは図形を際立たせ、プレゼンテーションに目を引くビジュアル要素を追加します。最小限のコードで実装でき、スライド全体の外観を向上させます。

この Java コードは、図形に[光彩エフェクト](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) を適用する方法を示しています。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![光彩エフェクト](glow_effect.png)

## **ソフトエッジエフェクトの適用**

Aspose.Slides for Android via Java でソフトエッジエフェクトを適用するには、図形のエッジ周辺に滑らかでぼやけた遷移を作り出します。このエフェクトは、より繊細で洗練された外観を与え、柔らかい印象が必要なデザインに最適です。半径などのパラメーターを簡単に調整して、プレゼンテーション内のさまざまな図形に希望の効果を実現できます。

この Java コードは、図形に[ソフトエッジエフェクト](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) を適用する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ソフトエッジエフェクト](soft_edges_effect.png)

## **ぼかしエフェクトの適用**

形状のぼかしを使用すると、図形の塗りつぶしとアウトラインをソフトにしながら、図形自体は編集可能なままにできます。図形のエフェクト フォーマットで [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) を呼び出します。半径はポイント (1/72 インチ) 単位で測定し、負の値は使用できません。数値が大きいほどぼかしが強くなります。半径を 0 に設定すると外観は変わりません。

[getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) 設定はエフェクトの可視領域を制御します。`false` の場合、ぼかしは元の塗りつぶし領域（アウトラインを含む）にクリップされます。`true` の場合、ぼかしはその領域を超えて伸びることができます。どちらの設定も図形の位置やサイズは変更しません。

以下の比較は、同じ塗りつぶし、アウトライン、図形サイズを使用しています。上段は `grow = false`、下段は `grow = true` です。

![元の矩形とぼかし半径 5 ポイント・15 ポイントの比較、grow 無効・有効](shape_blur_comparison.png)

この Java の例は、オレンジ色の矩形に濃い青のアウトラインを付け、5 ポイントのぼかしを適用し、続いて [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) を再度呼び出して 15 ポイントに更新します。両方のぼかし状態を保存した後、[disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) を呼び出してぼかしなしの図形を保存します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

形状のぼかしは塗りつぶしとアウトラインの両方に影響します。ソフトエッジエフェクトは図形のエッジをフェードさせ、影のぼかしは影だけを柔らかくします。画像変換エフェクトは画像コンテンツに作用しますが、この例は図形を画像に変換せず、直接図形のエフェクト フォーマットにぼかしを適用しています。

## **FAQ**

**同じ図形に複数のエフェクトを適用できますか？**

はい。影、反射、光彩などの異なるエフェクトを組み合わせて、1 つの図形に対してより動的な外観を作成できます。

**どのような図形にエフェクトを適用できますか？**

自動図形、グラフ、表、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形にエフェクトを適用できます。

**グループ化された図形にエフェクトを適用できますか？**

はい。グループ化された図形全体にエフェクトが適用されます。