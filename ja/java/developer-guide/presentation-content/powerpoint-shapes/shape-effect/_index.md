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
- エフェクトフォーマット
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PPT および PPTX ファイルを高度なシェイプ効果で変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **導入**

PowerPoint のエフェクトはシェイプを際立たせるために使用できますが、[塗りつぶし](/slides/ja/java/shape-formatting/#gradient-fill) やアウトラインとは異なります。PowerPoint のエフェクトを使用すると、シェイプにリアルな反射を作成したり、シェイプの光彩を広げたりできます。

![シェイプ効果](shape-effect.png)

PowerPoint にはシェイプに適用できる 6 つのエフェクトが用意されています。1 つまたは複数のエフェクトをシェイプに適用できます。

エフェクトの組み合わせによって見栄えが異なります。このため、PowerPoint では **Preset** の下にオプションが用意されています。Preset オプションは、見た目が良いと分かっている 2 つ以上のエフェクトの組み合わせです。これにより、プリセットを選択するだけで、さまざまなエフェクトを試したり組み合わせたりする手間が省けます。

Aspose.Slides は [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) クラスのプロパティとメソッドを提供し、PowerPoint プレゼンテーションのシェイプに同じエフェクトを適用できます。

## **影（シャドウ）エフェクトの適用**

Aspose.Slides for Java はシェイプの外側シャドウと内側シャドウをサポートします。色、方向、距離、ぼかし半径をカスタマイズしてプレゼンテーションのデザインに合わせることができます。

### **外側シャドウの適用**

外側シャドウを使用すると、カードやパネルがスライドの背景から浮き上がって見えます。シャドウはシェイプの端を超えて広がり、シェイプがスライド上に持ち上げられたように見えます。色、方向、距離、ぼかし半径を調整してテンプレートの照明やスタイルに合わせてください。

この Java コードは矩形に対して [外側シャドウエフェクト](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) を適用する方法を示しています。

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

![シャドウ効果](shadow_effect.png)

### **内側シャドウの適用**

テンプレートのビジュアルスタイルを再現する際には、内側シャドウを使用してカードやパネルにへこみ感を与えます。外側シャドウはシェイプの外側に広がり、浮き上がって見えるのに対し、内側シャドウはエッジの内側を陰影付けします。

[enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) を呼び出し、次に [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) が返すシャドウを構成します。ぼかし半径の値が大きいほど、エッジは柔らかくなります。

この Java の例は、薄い青色のカードに濃い灰色の内側シャドウを付け、PPTX ファイルとして保存します。シャドウの方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです。

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

![内側シャドウ付きの薄い青色矩形](inner_shadow_effect.png)

内側シャドウを削除するには、シェイプのエフェクトフォーマットで [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) を呼び出してください。

## **反射エフェクトの適用**

Aspose.Slides for Java で反射エフェクトを適用するには、シェイプに鏡面のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。このエフェクトはシェイプに洗練された外観を与え、プレゼンテーションの美観を高めます。シンプルなコードで簡単に実装でき、複数の要素に対して一貫したデザインをすばやく適用できます。

この Java コードはシェイプに対して [反射エフェクト](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) を適用する方法を示しています。

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

## **光彩エフェクトの適用**

Aspose.Slides for Java でシェイプに光彩エフェクトを適用すると、シェイプの周囲に柔らかい光輪を追加できます。色やサイズなどのプロパティを調整して、シェイプを目立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで実装でき、スライド全体の外観を向上させます。

この Java コードはシェイプに対して [光彩エフェクト](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) を適用する方法を示しています。

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

## **ソフトエッジエフェクトの適用**

Aspose.Slides for Java でソフトエッジエフェクトを適用すると、シェイプのエッジ周辺に滑らかでぼやけたトランジションを作成できます。このエフェクトは、より微妙で洗練された外観を提供し、柔らかい外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまなシェイプに目的の効果を実現できます。

この Java コードはシェイプに対して [ソフトエッジエフェクト](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) を適用する方法を示しています。

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

## **ぼかしエフェクトの適用**

シェイプのぼかしを使用すると、塗りつぶしとアウトラインをソフトにしながらシェイプ自体は編集可能なままにできます。シェイプのエフェクトフォーマットで [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) を呼び出します。半径はポイント単位（1/72 インチ）で測定され、非負の値を使用します。値が大きいほどぼかしが強くなります。半径が 0 の場合は見た目は変わりません。

[getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) 設定はエフェクトの表示領域を制御します。`false` の場合、ぼかしは元の描画領域（アウトラインを含む）にクリップされます。`true` の場合、ぼかしはその領域を超えて拡張できます。どちらの設定でもシェイプの位置やサイズは変更されません。

下の比較は全体で同じ塗りつぶし、アウトライン、シェイプサイズを使用しています。上段は `grow = false`、下段は `grow = true` です。

![元の矩形とぼかし半径 5 ポイントおよび 15 ポイント、grow 無効・有効の比較](shape_blur_comparison.png)

この Java の例は、オレンジ色の矩形に濃い青色のアウトラインを付け、5 ポイントのぼかしを適用し、その後 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) を再度呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存した後、[disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) を呼び出してぼかしのないシェイプを保存します。

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

シェイプのぼかしは塗りつぶしとアウトラインの両方に影響します。ソフトエッジ効果はシェイプのエッジをフェードさせ、シャドウぼかしはシャドウのみを柔らかくします。画像変換エフェクトは画像コンテンツに対して作用しますが、この例はシェイプを画像に変換せず、直接シェイプのエフェクトフォーマットにぼかしを適用しています。

## **FAQ**

**同じシェイプに複数のエフェクトを適用できますか？**

はい、シャドウ、反射、光彩など異なるエフェクトを組み合わせて、1 つのシェイプに対してよりダイナミックな外観を作り出すことができます。

**どのようなシェイプにエフェクトを適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまなシェイプにエフェクトを適用できます。

**グループ化されたシェイプにエフェクトを適用できますか？**

はい、グループ化されたシェイプ全体にエフェクトを適用できます。エフェクトはグループ全体に対して適用されます。