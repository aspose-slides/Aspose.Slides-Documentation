---
title: Java を使用したプレゼンテーションでシェイプ効果を適用する
linktitle: シェイプ効果
type: docs
weight: 30
url: /ja/java/shape-effect/
keywords:
- シェイプ効果
- 影効果
- 反射効果
- 光彩効果
- ソフトエッジ効果
- エフェクト形式
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して高度なシェイプ効果で PPT と PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **導入**

PowerPoint のエフェクトはシェイプを目立たせるために使用できますが、[塗りつぶし](/slides/ja/java/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPoint のエフェクトを使用すると、シェイプにリアルな反射を付けたり、シェイプの光彩を広げたりできます。

![シェイプ効果](shape-effect.png)

PowerPoint にはシェイプに適用できる 6 つのエフェクトがあります。シェイプに 1 つまたは複数のエフェクトを適用できます。

エフェクトの組み合わせによっては見栄えが良くなるものとそうでないものがあります。このため、PowerPoint は **プリセット** オプションを提供しています。プリセットは、見栄えが良いと分かっている 2 つ以上のエフェクトの組み合わせです。プリセットを選択すれば、さまざまなエフェクトを試したり組み合わせたりする手間を省けます。

Aspose.Slides は [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) クラスのプロパティとメソッドを通じて、PowerPoint プレゼンテーション内のシェイプに同じエフェクトを適用できるようにします。

## **影効果を適用する**

Aspose.Slides for Java はシェイプの外側影と内側影をサポートしています。色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側影を適用する**

外側影を使用すると、カードやパネルがスライドの背景から際立ちます。影はシェイプの端を超えて伸び、シェイプがスライド上に浮き上がっているように見えます。色、方向、距離、ぼかし半径を調整して、テンプレートのライティングとスタイリングに合わせます。

この Java コードは、矩形に [外側影効果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) を適用する方法を示しています。

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

![影効果](shadow_effect.png)

#### **シェイプが回転したときの影の方向を制御する**

既定では、外側影はシェイプとともに回転します。異なる回転を持つシェイプを同じ方向から照らしたい場合は、`false` を渡して [setRotateShadowWithShape](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) を呼び出し、[setDirection](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setDirection-float-) で同じ方向を設定します。

この例では、左向きに 42 ポイントオフセットした灰色の影を持つ青い矢印を 2 本作成します。その後スライドを複製し、両矢印を時計回りに 90° 回転させます。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.GRAY);
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

2 枚目のスライドでは、左側の矢印の影は下向きに落ち、右側の矢印の影は依然として右向きです。設定された方向は両方の影で 0° のままです。

![PowerPoint の 90° 回転前後の表示。両方の影は右側から開始し、回転後は左矢印の下に、右矢印の右側に残ります。](arrow-shadow-rotation.png)

### **内側影を適用する**

テンプレートのビジュアルスタイルを再現する際は、内側影を使用してカードやパネルに凹み感を与えます。外側影はシェイプの外側に広がって浮き上がって見えるのに対し、内側影はエッジの内部を陰影付けします。

まず [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) を呼び出し、次に [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) で取得した影を設定します。ぼかし半径を大きくすると、エッジが柔らかくなります。

この Java の例は、淡い青色のカードに濃い灰色の内側影を付けて PPTX ファイルとして保存します。影の方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです。

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

![内側影付きの淡青色矩形](inner_shadow_effect.png)

内側影を削除するには、シェイプのエフェクト形式に対して [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) を呼び出します。

### **プリセット影を適用、変更、削除する**

[enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) を呼び出し、[setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) で [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/) を選択します。同じシェイプ上でプリセットを変更すればスタイルを切り替えられます。影だけを削除したい場合は、[disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) を呼び出し、塗りとアウトラインは保持されます。

この例は、1 枚のスライドに 4 つの段階を横並びで示しています。両方の影は 10 ポイントオフセットしています。225° の方向は最初の影を矩形の左上に配置し、45° の方向は 2 番目の影を右下に配置します。

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

| 元の画像 | 最初のプリセット | 2 番目のプリセット | 削除後 |
| :---: | :---: | :---: | :---: |
| ![影なし](preset_shadow_original.png) | ![左上ドロップ影](preset_shadow_top_left.png) | ![右下ドロップ影](preset_shadow_bottom_right.png) | ![削除後の影なし](preset_shadow_removed.png) |

## **反射効果を適用する**

Aspose.Slides for Java で反射効果を適用するには、シェイプに鏡面のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。この効果により、プレゼンテーションの外観がより洗練されます。簡単なコードで実装でき、複数の要素に一貫したデザインを素早く適用できます。

この Java コードは、シェイプに [反射効果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) を適用する方法を示しています。

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

![反射効果](reflection_effect.png)

## **光彩効果を適用する**

Aspose.Slides for Java で光彩効果を適用するには、シェイプの周囲に柔らかい光のオーラを追加し、色やサイズなどのプロパティを調整します。この効果によりシェイプが際立ち、プレゼンテーションに目を引くビジュアル要素が加わります。最小限のコードで実装でき、スライド全体の見た目を向上させます。

この Java コードは、シェイプに [光彩効果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) を適用する方法を示しています。

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

![光彩効果](glow_effect.png)

## **ソフトエッジ効果を適用する**

Aspose.Slides for Java でソフトエッジ効果を適用すると、シェイプのエッジ周辺に滑らかでぼやけたトランジションを作成できます。この効果は、デザインに控えめで洗練された外観を与えます。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまなシェイプに適用できます。

この Java コードは、シェイプに [ソフトエッジ効果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) を適用する方法を示しています。

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

![ソフトエッジ効果](soft_edges_effect.png)

## **ぼかし効果を適用する**

シェイプぼかしを使用すると、シェイプの塗りとアウトラインをソフトにしながら、シェイプ自体は編集可能なままにできます。シェイプのエフェクト形式に対して [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) を呼び出します。半径はポイント (1/72 インチ) で測定し、非負の値を使用します。数値が大きいほどぼかしが強くなります。半径が 0 の場合は外観は変わりません。

[getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) 設定は効果の可視範囲を制御します。`false` の場合、ぼかしは元の塗り範囲 (アウトラインを含む) にクリップされます。`true` の場合、ぼかしはその範囲を超えて広がります。どちらの設定でもシェイプの位置やサイズは変更されません。

以下の比較は、同一の塗り、アウトライン、シェイプサイズを使用しています。上段は `grow = false`、下段は `grow = true` です。

![元の矩形と 5 ポイント・15 ポイントのぼかし半径の比較、grow 無効・有効](shape_blur_comparison.png)

この Java の例は、オレンジ色の矩形に濃い青のアウトラインを付け、5 ポイントのぼかしを適用し、続いて [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) を再度呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存した後、[disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) を呼び出してぼかしなしのシェイプを保存します。

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

シェイプぼかしは塗りとアウトラインの両方に影響します。ソフトエッジ効果はシェイプのエッジをフェードさせ、影ぼかしは影だけをソフトにします。画像変換効果は画像コンテンツに適用されますが、この例はシェイプを画像に変換せず、直接シェイプのエフェクト形式にぼかしを適用しています。

## **FAQ**

**同じシェイプに複数の効果を適用できますか？**

はい、影、反射、光彩など異なる効果を組み合わせて、シェイプをより動的に表現できます。

**どのシェイプに効果を適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt、OLE オブジェクトなど、さまざまなシェイプに効果を適用できます。

**グループ化したシェイプに効果を適用できますか？**

はい、グループ化したシェイプ全体に効果が適用されます。