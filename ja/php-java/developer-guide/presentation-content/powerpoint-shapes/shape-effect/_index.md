---
title: PHP を使用したプレゼンテーションでシェイプエフェクトを適用する
linktitle: シェイプエフェクト
type: docs
weight: 30
url: /ja/php-java/shape-effect/
keywords:
- シェイプエフェクト
- 影エフェクト
- 反射エフェクト
- 光彩エフェクト
- ソフトエッジエフェクト
- エフェクト形式
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して高度なシェイプエフェクトで PPT と PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **イントロダクション**

PowerPoint のエフェクトはシェイプを目立たせるために使用できますが、[塗りつぶし](/slides/ja/php-java/shape-formatting/#gradient-fill)や輪郭とは異なります。PowerPoint のエフェクトを使用すると、シェイプにリアルな反射を作成したり、シェイプのグロウを広げたりできます。

![シェイプ エフェクト](shape-effect.png)

PowerPoint はシェイプに適用できる 6 つのエフェクトを提供しています。シェイプに 1 つまたは複数のエフェクトを適用できます。

エフェクトの組み合わせの中には他より見栄えが良いものがあります。このため、PowerPoint は **Preset** の下にオプションを提供しています。Preset オプションは、見栄えが良いと判明している 2 つ以上のエフェクトの組み合わせです。これにより、プリセットを選択するだけで、さまざまなエフェクトをテストしたり組み合わせたりして良い組み合わせを探す時間を無駄にしません。

Aspose.Slides は、PowerPoint プレゼンテーションのシェイプに同じエフェクトを適用できるようにする、[EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供しています。

## **影エフェクトの適用**

Aspose.Slides for PHP via Java はシェイプに対する外部影と内部影をサポートしています。プレゼンテーションのデザインに合わせて、影の色、方向、距離、ぼかし半径をカスタマイズできます。

### **外部影の適用**

外部影を使用すると、カードやパネルがスライドの背景に対して際立ちます。影はシェイプのエッジの外側まで広がり、シェイプがスライド上に浮き上がっているように見えます。テンプレートの照明やスタイルに合わせて、影の色、方向、距離、ぼかし半径を調整してください。

この PHP コードは、矩形に [外部影エフェクト](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) を適用する方法を示しています:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![影エフェクト](shadow_effect.png)

### **内部影の適用**

テンプレートのビジュアルスタイルを再現する際は、カードやパネルに凹んだ外観を与えるために内部影を使用します。外部影はシェイプの外側に広がり、浮き上がっているように見せますが、内部影はエッジの内側に影を付けます。

まず [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) を呼び出し、次に [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) が返す影を構成します。ぼかし半径の値が大きいほど、エッジが柔らかくなります。

この PHP の例は、薄い青のカードに濃いグレーの内部影を作成し、PPTX ファイルとして保存します。影の方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです:
```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![内部影付きのライトブルー矩形](inner_shadow_effect.png)

内部影を削除するには、シェイプの EffectFormat で [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) を呼び出します。

## **反射エフェクトの適用**

Aspose.Slides for PHP via Java で反射エフェクトを適用するには、シェイプに鏡のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。このエフェクトはシェイプに洗練された外観を与え、プレゼンテーションの美しさを高めます。シンプルなコードで簡単に実装でき、複数の要素に素早く適用してデザインの一貫性を保てます。

この PHP コードは、シェイプに [反射エフェクト](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) を適用する方法を示しています:
```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![反射エフェクト](reflection_effect.png)

## **光彩エフェクトの適用**

Aspose.Slides for PHP via Java でシェイプに光彩エフェクトを適用するには、シェイプの周囲に柔らかく光るオーラを付加し、色やサイズなどのプロパティを調整します。このエフェクトはシェイプを際立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の見た目を向上させます。

この PHP コードは、シェイプに [光彩エフェクト](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) を適用する方法を示しています:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![光彩エフェクト](glow_effect.png)

## **ソフトエッジエフェクトの適用**

Aspose.Slides for PHP via Java でソフトエッジエフェクトを適用するには、シェイプのエッジ周辺に滑らかでぼかされたトランジションを作成します。このエフェクトは、より繊細で洗練された外観を加え、柔らかく穏やかな外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまなシェイプに目的のエフェクトを適用できます。

この PHP コードは、シェイプに [ソフトエッジエフェクト](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) を適用する方法を示しています:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![ソフトエッジエフェクト](soft_edges_effect.png)

## **ぼかしエフェクトの適用**

シェイプのぼかしを使用すると、シェイプの塗りつぶしと輪郭をソフトにしながら、シェイプを編集可能なままにできます。シェイプの EffectFormat で [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) を呼び出します。半径はポイント単位（1/72 インチ）で測定され、負の値は使用できません。値が大きいほどぼかしが強くなります。半径を 0 にすると外観は変わりません。

[getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) 設定はエフェクトの表示範囲を制御します。`false` の場合、ぼかしは元の描画領域（輪郭を含む）にクリップされます。`true` の場合、ぼかしはその領域を超えて拡張できます。どちらの設定もシェイプの位置やサイズは変更しません。

以下の比較は、全体で同じ塗りつぶし、輪郭、シェイプのサイズを使用しています。上段は `grow = false`、下段は `grow = true` を使用しています。

![ぼかし半径 5 ポイントと 15 ポイント、grow 無効・有効の比較（元の矩形）](shape_blur_comparison.png)

この PHP の例は、オレンジの矩形に濃い青の輪郭を付け、5 ポイントのぼかしを適用し、再度 [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) を呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存し、次に [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) を呼び出してぼかしのないシェイプを保存します。
```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

シェイプのぼかしは塗りつぶしと輪郭の両方に影響します。ソフトエッジエフェクトはシェイプのエッジをフェードさせ、影のぼかしは影だけをソフトにします。画像変換エフェクトは画像コンテンツに対して作用しますが、この例はシェイプを画像に変換せずに、シェイプの EffectFormat に直接ぼかしを適用しています。

## **よくある質問**

**同じシェイプに複数のエフェクトを適用できますか？**

はい、影、反射、光彩などの異なるエフェクトを単一のシェイプに組み合わせて、より動的な外観を作成できます。

**どのシェイプにエフェクトを適用できますか？**

自動シェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまなシェイプにエフェクトを適用できます。

**グループ化されたシェイプにエフェクトを適用できますか？**

はい、グループ化されたシェイプにもエフェクトを適用できます。エフェクトはグループ全体に適用されます。