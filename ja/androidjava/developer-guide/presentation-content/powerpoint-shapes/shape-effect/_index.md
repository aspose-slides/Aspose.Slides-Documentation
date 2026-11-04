---
title: Android でのプレゼンテーションにシェイプ効果を適用する
linktitle: シェイプ効果
type: docs
weight: 30
url: /ja/androidjava/shape-effect/
keywords:
- シェイプ効果
- 影効果
- 反射効果
- 発光効果
- ソフトエッジ効果
- エフェクト形式
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して高度なシェイプ効果で PPT および PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成できます。"
---
## **概要**

PowerPoint の効果は図形を目立たせるために使用できますが、[塗りつぶし](/slides/ja/androidjava/shape-formatting/#gradient-fill)や輪郭とは異なります。PowerPoint の効果を使用すると、図形にリアルな反射を作成したり、図形の発光を広げたりできます。

![シェイプ効果](shape-effect.png)

PowerPoint には図形に適用できる 6 つの効果が用意されています。1 つまたは複数の効果を図形に適用できます。

効果の組み合わせには見栄えの良し悪しがあります。そのため、PowerPoint では **Preset** の下にオプションが用意されています。Preset オプションは、見栄えが良いと判断された 2 つ以上の効果の組み合わせです。これにより、プリセットを選択するだけで、効果の組み合わせを試したり調整したりする手間が省けます。

Aspose.Slides は [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) クラスのプロパティとメソッドを通じて、PowerPoint プレゼンテーションの図形に同様の効果を適用できるようにします。

## **影の効果を適用する**

Aspose.Slides for Android via Java は図形に対して外側と内側の影をサポートします。色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側の影を適用する**

外側の影を使用すると、カードやパネルがスライドの背景から際立ちます。影は図形のエッジを超えて広がり、図形がスライド上に浮き上がっているように見せます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明とスタイリングに合わせます。

この Java コードは矩形に[外側の影エフェクト](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) を適用する方法を示しています。

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

![影の効果](shadow_effect.png)

### **内側の影を適用する**

テンプレートのビジュアルスタイルを再現する際に、カードやパネルに凹み感を与える内側の影を使用します。外側の影は図形の外側に広がり浮き上がって見えるのに対し、内側の影はエッジ内部を暗くして凹んだように見せます。

[enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) を呼び出し、続いて [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) が返す影を設定します。ぼかし半径を大きくすると、エッジがより柔らかくなります。

この Java の例は、薄い青のカードに濃いグレーの内側の影を付けて PPTX ファイルとして保存します。影の方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです。

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

![内側の影付き薄い青の矩形](inner_shadow_effect.png)

内側の影を削除するには、図形の effect format に対して [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) を呼び出します。

## **反射の効果を適用する**

Aspose.Slides for Android via Java で反射効果を適用するには、図形に鏡面のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。この効果は図形に洗練された外観を与え、プレゼンテーションの美しさを高めます。シンプルなコードで簡単に実装でき、複数の要素に対して一貫したデザインを迅速に適用できます。

この Java コードは図形に[反射エフェクト](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) を適用する方法を示しています。

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

## **発光の効果を適用する**

Aspose.Slides for Android via Java で図形に発光効果を適用すると、図形の周囲に柔らかな光のオーラを加えることができます。色やサイズなどのプロパティを調整して、図形を際立たせ、プレゼンテーションに目を引くビジュアル要素を追加します。最小限のコードで簡単に実装でき、スライド全体の外観を向上させます。

この Java コードは図形に[発光エフェクト](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) を適用する方法を示しています。

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

![発光効果](glow_effect.png)

## **ソフトエッジ効果を適用する**

Aspose.Slides for Android via Java でソフトエッジ効果を適用すると、図形のエッジ周辺に滑らかでぼやけたトランジションを作り出せます。この効果は、より微妙で洗練された外観を提供し、柔らかい外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな図形に目的の効果を適用できます。

この Java コードは図形に[ソフトエッジ効果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) を適用する方法を示しています。

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

形状のぼかしを使用すると、図形の塗りつぶしと輪郭を柔らかくしながら、図形自体は編集可能なままにできます。図形の effect format に対して [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) を呼び出します。半径はポイント単位 (1/72 インチ) で測定し、非負の値を指定します。値が大きいほど強いぼかしになります。半径が 0 の場合、外観は変わりません。

[getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) 設定は効果の可視領域を制御します。`false` の場合、ぼかしは元の塗りつぶし領域（輪郭を含む）にクリップされます。`true` の場合、ぼかしはその領域を超えて広がります。どちらの設定でも図形の位置やサイズは変更されません。

以下の比較は、全体で同じ塗りつぶし、輪郭、図形サイズを使用しています。上段が `grow = false`、下段が `grow = true` です。

![元の矩形とぼかし半径 5 ポイント・15 ポイント、grow 無効・有効の比較](shape_blur_comparison.png)

この Java の例は、オレンジの矩形に濃い青の輪郭を付け、5 ポイントのぼかしを適用し、続いて [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) を再度呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存した後、[disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) を呼び出し、ぼかしなしの図形を保存します。

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

形状のぼかしは塗りつぶしと輪郭の両方に影響します。ソフトエッジ効果は図形のエッジをフェードさせ、影のぼかしは影だけを柔らかくします。画像変換効果は画像コンテンツに適用されますが、この例では図形を画像に変換せず、直接図形の effect format にぼかしを適用しています。

## **FAQ**

**同じ図形に複数の効果を適用できますか？**

はい、影、反射、発光などの異なる効果を組み合わせて、1 つの図形に動的な外観を付与できます。

**どの図形に効果を適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形に効果を適用できます。

**グループ化された図形に効果を適用できますか？**

はい、グループ化された図形全体に効果を適用できます。効果はグループ全体に適用されます。