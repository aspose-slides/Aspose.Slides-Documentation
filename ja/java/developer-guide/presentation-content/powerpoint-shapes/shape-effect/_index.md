---
title: Java を使用したプレゼンテーションでの図形エフェクトの適用
linktitle: 図形エフェクト
type: docs
weight: 30
url: /ja/java/shape-effect/
keywords:
- 図形エフェクト
- 影エフェクト
- 反射エフェクト
- 発光エフェクト
- ソフトエッジエフェクト
- エフェクト形式
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して高度な図形エフェクトで PPT および PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **概要**

PowerPoint のエフェクトは図形を際立たせるために使用できますが、[塗りつぶし](/slides/ja/java/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPoint のエフェクトを使用すると、図形にリアルな反射を作成したり、図形の発光を広げたりすることができます。

![形状エフェクト](shape-effect.png)

PowerPoint には図形に適用できる 6 種類のエフェクトが用意されています。1 つまたは複数のエフェクトを図形に適用できます。

いくつかのエフェクトの組み合わせは他よりも見栄えが良くなります。そのため、PowerPoint では **プリセット** のオプションが提供されています。プリセットは、見栄えが良いと分かっている 2 つ以上のエフェクトの組み合わせです。プリセットを選択すれば、時間をかけてエフェクトを試したり組み合わせたりして最適な組み合わせを探す必要がなくなります。

Aspose.Slides では、PowerPoint プレゼンテーションの図形に同じエフェクトを適用できるよう、[EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) クラスのプロパティとメソッドが提供されています。

## **影のエフェクトを適用する**

Aspose.Slides for Java は図形の外側および内側の影をサポートしています。色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側の影を適用する**

外側の影を使用すると、カードやパネルがスライドの背景に対して際立ちます。影は図形の端を超えて広がり、図形がスライド上で持ち上げられたように見えます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせます。

This Java code shows how to apply the [外側影エフェクト](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) to a rectangle:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![影のエフェクト](shadow_effect.png)

### **内側の影を適用する**

テンプレートのビジュアルスタイルを再現する際は、内側の影を使用してカードやパネルにくぼんだ外観を付与します。外側の影は図形の外側に広がり持ち上げられたように見せますが、内側の影はエッジの内側に陰影を付けます。

[enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) を呼び出し、続いて [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) が返す影を設定します。ぼかし半径の値を大きくすると、エッジがより柔らかくなります。

この Java の例は、ライトブルーのカードにダークグレーの内側の影を付けて PPTX ファイルとして保存します。影の方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![内側の影があるライトブルーの長方形](inner_shadow_effect.png)

内側の影を削除するには、図形の EffectFormat で [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) を呼び出します。

### **プリセット影を適用、変更、削除する**

[enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) を呼び出し、[setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) を使って [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/) を選択します。同じ図形でスタイルを切り替えるには、プリセットを変更します。[disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) を呼び出すと、塗りつぶしとアウトラインは保持したまま影を削除できます。

この例は、1 つのスライド上に 4 つの段階を横並びで示しています。両方の影は 10 ポイントオフセットされています。方向が 225° の場合、最初の影は長方形の上左に配置され、45° の場合、2 つ目の影は下右に配置されます。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
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

| 元の状態 | 最初のプリセット | 2 番目のプリセット | 削除後 |
| :---: | :---: | :---: | :---: |
| ![影なし](preset_shadow_original.png) | ![左上ドロップシャドウ](preset_shadow_top_left.png) | ![右下ドロップシャドウ](preset_shadow_bottom_right.png) | ![削除後の影なし](preset_shadow_removed.png) |

## **反射エフェクトを適用する**

Aspose.Slides for Java で反射エフェクトを適用するには、図形に鏡面のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。このエフェクトは、図形により洗練された外観を与えることでプレゼンテーションの美しさを高めます。シンプルなコードで簡単に実装でき、複数の要素に一貫したデザインを迅速に適用できます。

This Java code shows how to apply the [反射エフェクト](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) to a shape:

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

## **発光エフェクトを適用する**

Aspose.Slides for Java で発光エフェクトを図形に適用すると、図形の周囲に柔らかな光のオーラを追加でき、色やサイズなどのプロパティを調整します。このエフェクトは図形を際立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の見栄えを向上させます。

This Java code shows how to apply the [発光エフェクト](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) to a shape:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![発光エフェクト](glow_effect.png)

## **ソフトエッジエフェクトを適用する**

Aspose.Slides for Java でソフトエッジエフェクトを適用すると、図形のエッジ周辺に滑らかでぼやけた遷移を作り出せます。このエフェクトはより繊細で洗練された外観を加え、柔らかい印象が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな図形に期待通りの効果を実現できます。

This Java code shows how to apply the [ソフトエッジエフェクト](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) to a shape:

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

## **ぼかしエフェクトを適用する**

形状のぼかしを使用すると、形状の塗りつぶしとアウトラインを保持しながらソフトにできます。形状の EffectFormat で [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) を呼び出します。半径はポイント単位 (1/72 インチ) で指定し、非負の値を使用します。値が大きいほど強いぼかしになります。半径が 0 の場合、外観は変わりません。

[getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) 設定はエフェクトの可視境界を制御します。`false` の場合、ぼかしは元の描画範囲（アウトラインを含む）にクリップされます。`true` の場合、ぼかしはその境界を超えて広がることができます。どちらの設定も形状の位置や寸法は変更しません。

以下の比較は、同じ塗りつぶし、アウトライン、形状サイズを使用しています。上段は `grow = false`、下段は `grow = true` です。

![ぼかし半径 5 ポイントと 15 ポイント、grow 無効と有効の比較（元の長方形）](shape_blur_comparison.png)

この Java の例はオレンジの長方形にダークブルーのアウトラインを付け、5 ポイントのぼかしを適用し、続いて [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) を再度呼び出して 15 ポイントに更新します。両方のぼかし状態を保存した後、[disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) を呼び出してぼかしなしの形状を保存します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
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

形状のぼかしは塗りつぶしとアウトラインの両方に影響します。ソフトエッジエフェクトは形状のエッジをフェードさせ、影のぼかしは影だけをソフトにします。画像変換エフェクトは画像コンテンツに対して作用しますが、この例では形状を画像に変換せず、直接形状の EffectFormat にぼかしを適用しています。

## **よくある質問**

**同じ図形に複数のエフェクトを適用できますか？**

はい、影、反射、発光などの異なるエフェクトを単一の図形に組み合わせて、より動的な外観を作成できます。

**どのような図形にエフェクトを適用できますか？**

自動図形、チャート、表、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形にエフェクトを適用できます。

**グループ化された図形にエフェクトを適用できますか？**

はい、グループ化された図形にもエフェクトを適用できます。エフェクトはグループ全体に適用されます。