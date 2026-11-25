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
- グロー効果
- ソフトエッジ効果
- 効果フォーマット
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して高度なシェイプ効果で PPT および PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **紹介**

PowerPoint の効果は図形を際立たせるために使用できますが、[塗りつぶし](/slides/ja/androidjava/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPoint の効果を使用すると、図形に説得力のある反射を作成したり、図形のグローを広げたりすることができます。

![影効果](shape-effect.png)

PowerPoint には図形に適用できる 6 つの効果が用意されています。1 つまたは複数の効果を図形に適用できます。

効果の組み合わせの中には、他よりも見栄えが良いものがあります。そのため、PowerPoint は **Preset** の下にオプションを提供しています。Preset オプションは、見栄えが良いと分かっている 2 つ以上の効果の組み合わせです。このように、プリセットを選択すれば、異なる効果を試したり組み合わせたりして良い組み合わせを見つける時間を無駄にする必要がありません。

Aspose.Slides は、PowerPoint プレゼンテーションの図形に同じ効果を適用できるように、[EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) クラスのプロパティとメソッドを提供しています。

## **影効果の適用**

Aspose.Slides for Android via Java は、図形に対して外側と内側の影をサポートしています。影の色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側の影の適用**

外側の影を使用して、カードやパネルをスライドの背景から際立たせます。影は図形のエッジの外側に広がり、図形がスライド上に持ち上げられたように見せます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせます。

この Java コードは、長方形に [外側影効果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) を適用する方法を示しています：
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

![影効果](shadow_effect.png)

### **内側の影の適用**

テンプレートのビジュアルスタイルを再現する際は、カードやパネルに凹んだ外観を与えるために内側の影を使用します。外側の影は図形の外側に広がり、持ち上げられたように見せますが、内側の影はエッジの内部を陰影付けします。

[enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) を呼び出し、次に [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) が返す影を設定します。ぼかし半径の値が大きいほど、エッジが柔らかくなります。

この Java の例は、明るい青色のカードに濃い灰色の内側の影を付け、PPTX ファイルとして保存します。影の方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです：
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

![内側の影付きライトブルー長方形](inner_shadow_effect.png)

内側の影を削除するには、図形の effect format で [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) を呼び出します。

### **プリセット影の適用、変更、削除**

[enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) を呼び出し、[setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-) を使用して [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/) を選択します。同じ図形でスタイルを切り替えるには、プリセットを変更します。[disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) を呼び出すと、塗りつぶしとアウトラインを保持したまま影を削除できます。

この例は、1 つのスライド上に 4 つの段階を横に並べて示しています。両方の影は 10 ポイントオフセットされています。方向が 225° の場合、最初の影は長方形の上部左側に配置され、45° の場合、2 番目の影は下部右側に配置されます。
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

| オリジナル | 最初のプリセット | 2 番目のプリセット | 削除後 |
| :---: | :---: | :---: | :---: |
| ![影なし](preset_shadow_original.png) | ![左上ドロップシャドウ](preset_shadow_top_left.png) | ![右下ドロップシャドウ](preset_shadow_bottom_right.png) | ![削除後の影なし](preset_shadow_removed.png) |

## **反射効果の適用**

Aspose.Slides for Android via Java で反射効果を適用するには、図形に鏡のような反射を追加し、距離、透明度、サイズなどのパラメータを調整できます。この効果は、図形により洗練された外観を与えることでプレゼンテーションの美観を向上させます。シンプルなコードで簡単に実装でき、複数の要素に素早く適用してデザインの一貫性を保てます。

この Java コードは、図形に [反射効果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) を適用する方法を示しています：
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

## **グロー効果の適用**

Aspose.Slides for Android via Java で図形にグロー効果を適用するには、色やサイズなどのプロパティを調整しながら、図形の周囲に柔らかく光るオーラを追加できます。この効果は図形を際立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の外観を向上させます。

この Java コードは、図形に [グロー効果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) を適用する方法を示しています：
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

![グロー効果](glow_effect.png)

## **ソフトエッジ効果の適用**

Aspose.Slides for Android via Java でソフトエッジ効果を適用すると、図形のエッジ周辺に滑らかでぼやけた遷移を作成できます。この効果は、より繊細で洗練された外観を加え、やわらかい外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな図形に期待どおりの効果を得られます。

この Java コードは、図形に [ソフトエッジ効果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) を適用する方法を示しています：
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

## **ぼかし効果の適用**

形状のぼかしを使用すると、図形の塗りつぶしとアウトラインを柔らかくしながら、図形は編集可能なままにできます。図形の effect format で [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) を呼び出します。半径はポイント単位（1/72 インチ）で測定され、非負の値を使用し、値が大きいほど強いぼかしになります。半径が 0 の場合、外観は変わりません。

[getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) 設定は、効果の可視境界を制御します。`false` の場合、ぼかしは元の描画境界（アウトラインを含む）にクリップされます。`true` の場合、ぼかしはその境界を超えて広がることができます。どちらの設定も図形の位置やサイズは変更しません。

以下の比較では、同じ塗りつぶし、アウトライン、図形サイズを使用しています。上段は `grow = false`、下段は `grow = true` を使用しています。

![ぼかし半径 5 と 15 ポイント、grow 無効/有効 の比較](shape_blur_comparison.png)

この Java の例は、オレンジ色の長方形に濃い青のアウトラインを付け、5 ポイントのぼかしを適用し、次に [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) を再び呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存し、その後 [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) を呼び出してぼかしなしで図形を保存します。
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

形状のぼかしは塗りつぶしとアウトラインの両方に影響します。ソフトエッジ効果は図形のエッジをフェードさせますが、影のぼかしは影だけを柔らかくします。画像変換効果は画像コンテンツに対して動作しますが、この例では図形を画像に変換せずに、直接図形の effect format にぼかしを適用しています。

## **よくある質問**

**同じ図形に複数の効果を適用できますか？**

はい、影、反射、グローなどの異なる効果を組み合わせて、単一の図形に適用し、より動的な外観を作成できます。

**どのような図形に効果を適用できますか？**

自動図形、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形に効果を適用できます。

**グループ化された図形に効果を適用できますか？**

はい、グループ化された図形に効果を適用できます。効果はグループ全体に適用されます。